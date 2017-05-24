import { Component, Input, /*Host,*/ ChangeDetectionStrategy, ChangeDetectorRef, ApplicationRef, NgZone } from '@angular/core';

import { Hero } from '../shared/hero';
import { HeroDetailComponent } from './hero-detail.component';
import { AppComponent } from '../app.component';

@Component({
    //moduleId: module.id,
    selector: 'my-hero-detail2',
    templateUrl: 'hero-detail2.component.html',
    styleUrls: ['hero-detail2.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class HeroDetailComponent2 extends HeroDetailComponent {
    //@Input()
    //hero: Hero;

    constructor(
        //@Host()
        private heroDetail: HeroDetailComponent,
        app: AppComponent,
        private appRef: ApplicationRef,
        private ref: ChangeDetectorRef,
        private zone: NgZone) {

        super(app);

        setInterval(() => {
            //(<any>this.appRef).changeDetectorRefs
            //    .forEach((ref) => ref.detectChanges());
            //this.appRef..markForCheck();

            //this.zone.run(() => this.tick());
        }, 2000);
    }
}