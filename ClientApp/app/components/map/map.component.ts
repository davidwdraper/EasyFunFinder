import { Component } from '@angular/core';
import { AgmCoreModule } from 'angular2-google-maps/core';
import { AppManagerService } from '../../services/app-manager.service';
import { DataChangeType } from '../../models/data-change-type.model';

@Component({
    selector: 'gmap',
    templateUrl: './map.component.html',
    styleUrls: ['./map.component.css'],
})

export class MapComponent {

    lat: number = 0;
    lng: number = 0;

    constructor(
        private _appMgr: AppManagerService
    ) {
        this._appMgr.dataChangeEvent.subscribe(type => this.onDataChange(type));
    }

    private onDataChange(type: DataChangeType) {
        if (type == DataChangeType.homeLatLngChanged ||
            type == DataChangeType.mapVisible ||
            (type == DataChangeType.pageChange && this._appMgr.currentPage == 'home')) {
            this.lat = this._appMgr.homeLat;
            this.lng = this._appMgr.homeLng;
        }
    }
}
