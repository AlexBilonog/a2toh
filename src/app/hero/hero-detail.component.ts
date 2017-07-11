import { Component, Input, /*Host,*/ ChangeDetectionStrategy } from '@angular/core';

import { Hero } from '../shared/hero';
import { AppComponent } from '../app.component';

@Component({
    //moduleId: module.id,
    selector: 'hero-detail',
    templateUrl: 'hero-detail.component.html',
    styleUrls: ['hero-detail.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class HeroDetailComponent {
    @Input() hero: Hero;

    constructor(
        /*@Host()*/ private app: AppComponent) {
    }
}