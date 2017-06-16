import { Component } from '@angular/core';

/*
Subscribes to the ResultsManager server
and listens for onResultsChanged.
The view controls which component to display based on 'resultType'

DESIGN NOTE
This component could make use of the Angular ComponentFactoryResolver and
we could inject which results view to show.  We may add that later,
but for now its KISS.  We have a known set of result types, so we've
chosen to do static ngIf logic in the view markup.
*/

@Component({
    selector: 'result-view-factory',
    templateUrl: './result-view-factory.component.html',
    styleUrls: ['./result-view-factory.component.css'],
})

export class ResultViewFactoryComponent {

    resultType: string = "business-list"; // to be passed in

    constructor() {
    }
}
