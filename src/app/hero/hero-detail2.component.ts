import { Component, Input, /*Host,*/ ChangeDetectionStrategy, ChangeDetectorRef, ApplicationRef, NgZone } from '@angular/core';
import { Hero } from './hero';
import { HeroesComponent } from './heroes.component';
import { HeroDetailComponent } from './hero-detail.component';

@Component({
    moduleId: module.id,
    selector: 'hero-detail2',
    templateUrl: 'hero-detail2.component.html',
    styleUrls: ['hero-detail2.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class HeroDetailComponent2 extends HeroDetailComponent {
    //@Input() hero: Hero;

    constructor(
        /*@Host()*/ private heroDetail: HeroDetailComponent,
        heroesComponent: HeroesComponent,
        private appRef: ApplicationRef,
        private ref: ChangeDetectorRef,
        private zone: NgZone) {

        super(heroesComponent);

        setInterval(() => {
            //(<any>this.appRef).changeDetectorRefs
            //    .forEach((ref) => ref.detectChanges());
            //this.appRef..markForCheck();

            //this.zone.run(() => this.tick());
        }, 2000);
    }
}