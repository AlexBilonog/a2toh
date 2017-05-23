import { Component, Input, /*Host,*/ ChangeDetectionStrategy } from '@angular/core';

import { Hero } from '../shared/hero';
import { AppComponent } from '../shared/app.component';

@Component({
    moduleId: module.id,
    selector: 'my-hero-detail',
    templateUrl: 'hero-detail.component.html',
    styleUrls: ['hero-detail.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class HeroDetailComponent {
    @Input()
    hero: Hero;

    constructor(
        //@Host()
        private app: AppComponent) {
    }
}