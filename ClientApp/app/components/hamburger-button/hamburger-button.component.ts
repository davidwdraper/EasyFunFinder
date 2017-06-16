import { Component } from '@angular/core';
import { AppManagerService } from '../../services/app-manager.service';
import { DataChangeType } from '../../models/data-change-type.model';

@Component({
    selector: 'hamburger',
    templateUrl: './hamburger-button.component.html',
    styleUrls: ['./hamburger-button.component.css']
})
export class HamburgerButtonComponent {

    constructor(
        private _appMgr: AppManagerService
    ) { }


    public onMenuClick() {
        this._appMgr.onDataChange(DataChangeType.menuClicked);
    }
}
