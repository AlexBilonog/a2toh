import { Component, Input, /*Host,*/ ChangeDetectionStrategy, ChangeDetectorRef, ApplicationRef, NgZone } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Hero } from './hero';
import { HeroDetailComponent } from './hero-detail.component';
import { HeroService } from './hero.service';

@Component({
    moduleId: module.id,
    selector: 'hero-detail2',
    templateUrl: 'hero-detail2.component.html',
    //styleUrls: ['hero-detail2.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class HeroDetailComponent2 extends HeroDetailComponent {
    @Input() hero: Hero;

    constructor(
        heroService: HeroService,
        route: ActivatedRoute,
        location: Location,

        /*@Host()*/ private heroDetail: HeroDetailComponent,
        private appRef: ApplicationRef,
        private ref: ChangeDetectorRef,
        private zone: NgZone) {

        super(heroService, route, location);

        setInterval(() => {
            //(<any>this.appRef).changeDetectorRefs
            //    .forEach((ref) => ref.detectChanges());
            //this.appRef..markForCheck();

            //this.zone.run(() => this.tick());
        }, 2000);
    }
}