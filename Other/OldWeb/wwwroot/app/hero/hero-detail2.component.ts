import { Component, Input, /*Host,*/ ChangeDetectionStrategy } from '@angular/core';
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
        /*@Host()*/ private heroDetail: HeroDetailComponent) {

        super(heroService, route, location);
    }
}