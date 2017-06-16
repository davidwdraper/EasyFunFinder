import { Injectable, Inject } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Rx'

import { AppManagerService } from './app-manager.service';
import { DataChangeType } from '../models/data-change-type.model';
import { User } from '../models/user.model';
import { UserProfile } from '../models/user-profile.model';

@Injectable()

export class UserService {

    constructor(
        private _http: Http,
        @Inject('ORIGIN_URL') private originUrl: string,
        private _appMgr: AppManagerService,
    ) {
        this._appMgr.dataChangeEvent.subscribe(type => this.onDataChange(type));
    }

    private onDataChange(type: DataChangeType) {

        // Check for a userChanged event. If we get one, we 
        //  reload the UserProfiles, then update the
        //  default profile with lat/lng that exists
        //  in the appMgr (loaded in the AppComponent)
        if (type == DataChangeType.userChanged) {
            this.getUserProfiles(this._appMgr.user.Id);
        }

        // defaultProfileChanged will fire as a result of
        //  calling getUserProfiles()
        if (type == DataChangeType.defaultProfileChanged) {
            if (this._appMgr.homeLat != this._appMgr.defaultProfile.Lat || this._appMgr.homeLng != this._appMgr.defaultProfile.Lng) {
                this._appMgr.defaultProfile.Lat = this._appMgr.homeLat;
                this._appMgr.defaultProfile.Lng = this._appMgr.homeLng;
                this.updateDefaultProfileLatLng();
                this._appMgr.onDataChange(DataChangeType.homeLatLngChanged);
            }
        }
    }

    private baseUrl(root: string): string {
        return this.originUrl + '/api/' + root + '/';
    }

    public ValidatePassword(cookie: string, email: string, password: string): Observable<boolean> {
        return this._http
            .put(this.baseUrl('user') + cookie + '/' + email, password)
            .map((response: Response) => <boolean>response.json())
            .catch(this.handleError);
    }

    //
    // Attempt to get a user via the cookie.  If a user is not
    //  found the backend will create a user and default profile.
    //  It is up to the caller to set the lat/lng of the profile
    //  in a subsequent call...
    //
    public getUser(cookie: string) {

        let url: string = this.baseUrl('user') + cookie + '/';
        return this._http
            .get(url)
            .map((response: Response) => <User>response.json())
            .do(data => console.log("User: " + data))
            .catch(this.handleError)
            .subscribe(result => this.loadUserCallback(result));
    }

    //
    // Insert or update a User.  If a user is not found,
    //  he/she is inerted and a default profile is created.
    //  It is up to the caller to set the lat/lng of the profile
    //  in a subsequent call...
    //
    public upsertUser(user: User) {
        return this._http
            .post(this.baseUrl('user'), user)
            .map((response: Response) => <User>response.json())
            .do(data => console.log("User: " + data))
            .catch(this.handleError)
            .subscribe(result => this.loadUserCallback(result));
    }

    //
    // Cache the user, and publish to the AppMgr that data has changed
    //
    private loadUserCallback(user: User) {
        this._appMgr.user = user;
        this._appMgr.onDataChange(DataChangeType.userChanged);
    }

    public updateDefaultProfileLatLng() {
        let url: string = this.baseUrl('userprofile') + 'latlng/' + this._appMgr.defaultProfile.Id + '/' + this._appMgr.homeLat + '/' + this._appMgr.homeLng + '/';
        return this._http
            .post(url, null)
            .catch(this.handleError);
    }

    public getUserProfiles(userId: number) {
        let url: string = this.baseUrl('userprofile') + 'user/' + userId + '/';
        return this._http
            .get(url)
            .map((response: Response) => <UserProfile[]>response.json())
            .do(data => console.log("UserProfile: " + data))
            .catch(this.handleError)
            .subscribe(result => this.loadUserProfilesCallback(result));
    }

    private loadUserProfilesCallback(userProfiles: UserProfile[]) {
        //Get the current profile
        for (let profile of userProfiles) {
            if (profile.DefaultProfile) {
                this.loadDefaultProfileCallback(profile.Id);
                break;
            }
        }

        this._appMgr.userProfiles = userProfiles;
        this._appMgr.onDataChange(DataChangeType.userProfilesChanged);
    }

    private loadDefaultProfileCallback(userProfileId: number) {
        let url: string = this.baseUrl('userprofile') + userProfileId + '/';
        return this._http
            .get(url)
            .map((response: Response) => <UserProfile>response.json())
            .do(data => console.log("Default-UserProfile: " + data))
            .catch(this.handleError)
            .subscribe(result => this.loadDefaultUserProfileCallback(result));
    }

    private loadDefaultUserProfileCallback(defaultUserProfile: UserProfile) {
        this._appMgr.defaultProfile = defaultUserProfile;
        this._appMgr.onDataChange(DataChangeType.defaultProfileChanged);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}