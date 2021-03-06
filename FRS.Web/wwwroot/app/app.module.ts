import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppRoutingModule } from './app-routing.module';
// Imports for loading & configuring the in-memory web api
//import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
//import { InMemoryDataService } from './in-memory-data.service';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { GridModule } from '@progress/kendo-angular-grid';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { JsonpModule } from '@angular/http';
import { GridService } from './common/grid.service';

import { AppComponent } from './app.component';
import { DashboardComponent } from './hero/dashboard.component';
import { HeroesComponent } from './hero/heroes.component';
import { HeroDetailComponent } from './hero/hero-detail.component';
import { HeroDetailComponent2 } from './hero/hero-detail2.component';
import { HeroService } from './hero/hero.service';
import { HeroSearchComponent } from './hero/hero-search.component';
import { ProductsComponent } from './products/products.component';
import { DropDownListFilterComponent } from './products/dropdownlist-filter.component';

@NgModule({
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        FormsModule,
        ReactiveFormsModule,
        AppRoutingModule,
        HttpModule,
        //InMemoryWebApiModule.forRoot(InMemoryDataService),
        ButtonsModule,
        GridModule,
        DropDownsModule,
        JsonpModule
    ],
    declarations: [
        AppComponent,
        DashboardComponent,
        HeroesComponent,
        HeroDetailComponent,
        HeroDetailComponent2,
        HeroSearchComponent,
        ProductsComponent,
        DropDownListFilterComponent
    ],
    providers: [
        HeroService,
        GridService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }