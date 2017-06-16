import { Injectable, Inject, Output, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs/Rx'

import { DataChangeType } from '../models/data-change-type.model';
import { User } from '../models/user.model';
import { UserProfile } from '../models/user-profile.model';

@Injectable()

//
// This Service manages all the application components responsible
//  for searching and displaying.
// Using the pub/sub model between this service and the application components,
//  loose coupling is enabled.
// This service will also cache search results to be re-used when
//  a user moves between pages without doing a search re-query.
//
export class AppManagerService {

    @Output()
    dataChangeEvent: EventEmitter<DataChangeType> = new EventEmitter<DataChangeType>();

    public currentPage: string;

    //
    // The current user. May or may not be signed in.
    //
    public user: User;

    //
    // 'Home' point to be pinned on the map and to be used as the center for radius searches
    //
    public homeLat: number = 0;
    public homeLng: number = 0;

    public userProfiles: UserProfile[];
    public defaultProfile: UserProfile;

    //
    // Components that change search result data, should
    //  call this method (publish), so that other components
    //  that are subscribing can update their displays...
    //
    public onDataChange(type: DataChangeType) {
        this.dataChangeEvent.emit(type);
    }
}