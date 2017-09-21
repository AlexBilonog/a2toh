import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppRoutingModule } from './app-routing.module';
// Imports for loading & configuring the in-memory web api
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemoryDataService } from './in-memory-data.service';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { GridModule } from '@progress/kendo-angular-grid';
import { JsonpModule } from '@angular/http';
import { GridService } from './shared/grid.service';

import { AppComponent } from './app.component';
import { DashboardComponent } from './hero/dashboard.component';
import { HeroesComponent } from './hero/heroes.component';
import { HeroDetailComponent } from './hero/hero-detail.component';
import { HeroDetailComponent2 } from './hero/hero-detail2.component';
import { HeroService } from './hero/hero.service';
import { HeroSearchComponent } from './hero/hero-search.component';
import { ProductsComponent } from './products/products.component';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        AppRoutingModule,
        HttpModule,
        InMemoryWebApiModule.forRoot(InMemoryDataService),
        ButtonsModule,
        GridModule,
        JsonpModule
    ],
    declarations: [
        AppComponent,
        DashboardComponent,
        HeroesComponent,
        HeroDetailComponent,
        HeroDetailComponent2,
        HeroSearchComponent,
        ProductsComponent
    ],
    providers: [
        HeroService,
        GridService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }