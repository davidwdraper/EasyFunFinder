import { Component } from '@angular/core';
import { CookieWrapperService } from '../services/cookie-wrapper.service';
import { AppManagerService } from '../services/app-manager.service';
import { UserService } from '../services/user.service';
import { Guid } from '../helpers/guid';
import { DataChangeType } from '../models/data-change-type.model';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    providers: [CookieWrapperService, Guid]
})

// The AppComponent attempts to load an
// existing user based on a cookie.
// If no cookie is found, then a new cookie
// is generated and inserted to the DB.
export class AppComponent {

    public isWindowSmall: boolean = false;

    constructor(
        private _appMgr: AppManagerService,
        private _userService: UserService,
        private _cookieService: CookieWrapperService
    ) {
        this.setWindowFlag(window.innerWidth);

        // Always grap the current location when the map loads.
        this.getMapHomePosition();
    }

    public onResize(event: any): void {
        this.setWindowFlag(event.target.innerWidth);
    }

    private setWindowFlag(width: number): void {
        this.isWindowSmall = width <= 600;
    }

    private _cookieName: string = "easyfunfinder";

        private getMapHomePosition() {
        navigator.geolocation.getCurrentPosition(
            position => this.onNewPositionCallback(position),
            error => this.noPosition(error),
            {
                enableHighAccuracy: true,
                timeout: 5000,
                maximumAge: 0
            }
        );
    }

    // Called when new position is retrieved from geolocation
    private onNewPositionCallback(position: any) {
        this._appMgr.homeLat = position.coords.latitude;
        this._appMgr.homeLng = position.coords.longitude;

        // Load existing or new user.
        // The UserService will subscribe to the userChanged event
        //  and ensure that the lat/lng is current for the default profile
        let cookieVal: string = this.setupCookie();
        this._userService.getUser(cookieVal);
    }

    noPosition(error: any) {
        // TODO: log that geolocation failed
    }

    private setupCookie(): string {
        let cookieVal: string = this._cookieService.get(this._cookieName);
        if (cookieVal == null) {
            // If a cookie doesn't exist, then create one...
            cookieVal = Guid.newGuid();
            this._cookieService.put(this._cookieName, cookieVal);
        }

        return cookieVal;
    }
}
