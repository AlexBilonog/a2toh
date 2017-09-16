import { Component } from '@angular/core';

@Component({
    moduleId: module.id,
    selector: 'my-app',
    templateUrl: 'app.component.html',
    styleUrls: [
        'app.component.css',
        //'../node_modules/@progress/kendo-theme-default/dist/all.css'
    ]
})
export class AppComponent {
    title = 'Tour of Heroes';
}