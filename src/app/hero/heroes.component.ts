import { Component, OnInit, /*ChangeDetectorRef,*/ ApplicationRef } from '@angular/core';
import { Router } from '@angular/router';
import { Hero } from './hero';
import { HeroService } from './hero.service';

@Component({
    moduleId: module.id,
    selector: 'heroes',
    templateUrl: 'heroes.component.html',
    styleUrls: ['heroes.component.css']
})
export class HeroesComponent implements OnInit {
    heroes: Hero[];
    selectedHero: Hero;

    constructor(
        private router: Router,
        private heroService: HeroService,
        //private ref: ChangeDetectorRef,
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

    goToDetail() {
        this.router.navigate(['/detail', this.selectedHero.id]);
    }
}