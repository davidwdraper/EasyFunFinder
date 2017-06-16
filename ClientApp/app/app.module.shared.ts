import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { CookieService } from 'angular2-cookie/services';

import { CollapseDirective } from 'ngx-bootstrap/collapse';
import { CookieWrapperService } from './services/cookie-wrapper.service';
import { UserService } from './services/user.service';
import { MyTestService } from './services/my-test.service';

import { AgmCoreModule } from 'angular2-google-maps/core';

import { AppComponent } from './app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { ResultViewComponent } from './components/result-view/result-view.component';
import { ResultViewFactoryComponent } from './components/result-view-factory/result-view-factory.component';
import { BusinessComponent } from './components/business/business.component';
import { BusinessListComponent } from './components/business-list/business-list.component';
import { EntertainerComponent } from './components/entertainer/entertainer.component';
import { EntertainerListComponent } from './components/entertainer-list/entertainer-list.component';
import { EventComponent } from './components/event/event.component';
import { EventListComponent } from './components/event-list/event-list.component';
import { EventTimesComponent } from './components/event-times/event-times.component';
import { PersonComponent } from './components/person/person.component';
import { PersonListComponent } from './components/person-list/person-list.component';
import { MapComponent } from './components/map/map.component';
import { HamburgerButtonComponent } from './components/hamburger-button/hamburger-button.component';

export const sharedConfig: NgModule = {
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CollapseDirective,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        ResultViewComponent,
        ResultViewFactoryComponent,
        BusinessComponent,
        BusinessListComponent,
        EntertainerComponent,
        EntertainerListComponent,
        EventComponent,
        EventListComponent,
        EventTimesComponent,
        PersonComponent,
        PersonListComponent,
        MapComponent,
        HamburgerButtonComponent
    ],
    providers: [
        MyTestService
    ],
    imports: [
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ]),
        AgmCoreModule.forRoot({
            apiKey: 'AIzaSyAOLo9PgzI_wLXPGwExhq6O_lqvwq_4j6Y'
        }),
    ]
};
