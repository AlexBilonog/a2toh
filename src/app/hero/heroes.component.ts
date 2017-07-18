import { Component, OnInit, ChangeDetectionStrategy, ChangeDetectorRef, ApplicationRef } from '@angular/core';
import { Hero } from './hero';
import { HeroService } from './hero.service';

@Component({
    moduleId: module.id,
    selector: 'heroes',
    templateUrl: 'heroes.component.html',
    styleUrls: ['heroes.component.css'],
    //providers: [HeroService],
    changeDetection: ChangeDetectionStrategy.Default
})
export class HeroesComponent implements OnInit {
    heroes: Hero[];
    selectedHero: Hero;

    constructor(
        private heroService: HeroService,
        private ref: ChangeDetectorRef,
        private appRef: ApplicationRef) {
    }

    ngOnInit() {
        this.heroService.getHeroes().then(r => this.heroes = r);
    }

    onSelect(hero: Hero) {
        this.selectedHero = hero;

        //this.appRef.tick();
        //this.ref.detach();
        //this.ref.markForCheck();
        //this.ref.reattach();
    }
}