import { Component } from '@angular/core';
import { AppManagerService } from '../../services/app-manager.service';
import { DataChangeType } from '../../models/data-change-type.model';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css'],
})
export class NavMenuComponent {
    public isCollapsed: boolean = true;

    constructor(
        private _appMgr: AppManagerService
    ) {
        this._appMgr.dataChangeEvent.subscribe(type => this.onDataChange(type));
    }

    private onDataChange(type: DataChangeType) {
        if (type == DataChangeType.menuClicked) {
            this.isCollapsed = !this.isCollapsed;
        }
    }

    public setPage(page: string) {
        this._appMgr.currentPage = page;
        this._appMgr.onDataChange(DataChangeType.pageChange);
    }
}
