import { Component, Output, EventEmitter } from '@angular/core';
import { AppManagerService } from '../../services/app-manager.service';
import { DataChangeType } from '../../models/data-change-type.model';

/*
    Wrapper for:
    - tab view of either the map or a results list
    - detail view of item from the map or list
    - also shows the radius used for the results
*/

@Component({
    selector: 'result-view',
    templateUrl: './result-view.component.html',
    styleUrls: ['./result-view.component.css'],
})

export class ResultViewComponent {

    public resultTitle: string = "Businesses"; // to be passed in
    public showMap: boolean = true;
    public radius: number = 10;

    constructor(
        private _appMgr: AppManagerService
    ) { }

    onShowMap(event) {
        this.showMap = event.target.checked;
        // tell the appMgr that we need to reshow the map
        if (this.showMap) {
            this._appMgr.onDataChange(DataChangeType.mapVisible);
        }
    }
}
