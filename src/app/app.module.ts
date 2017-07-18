import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';

//import { AppRoutingModule } from './app-routing.module';

// Imports for loading & configuring the in-memory web api
//import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
//import { InMemoryDataService }  from './in-memory-data.service';

import { AppComponent } from './app.component';
//import { DashboardComponent }   from './dashboard.component';
import { HeroesComponent } from './hero/heroes.component';
import { HeroDetailComponent } from './hero/hero-detail.component';
import { HeroDetailComponent2 } from './hero/hero-detail2.component';
import { HeroService } from './hero/hero.service';
//import { HeroSearchComponent }  from './hero-search.component';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        RouterModule.forRoot([
            {
                path: 'heroes',
                component: HeroesComponent
            }
        ]),
        HttpModule,
        //InMemoryWebApiModule.forRoot(InMemoryDataService),
        //AppRoutingModule
    ],
    declarations: [
        AppComponent,
        //DashboardComponent,
        HeroesComponent,
        HeroDetailComponent,
        HeroDetailComponent2,
        //HeroSearchComponent
    ],
    providers: [
        HeroService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }