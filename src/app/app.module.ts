import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HeroDetailComponent } from './hero/hero-detail.component';
import { HeroDetailComponent2 } from './hero/hero-detail2.component';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule
    ],
    declarations: [
        AppComponent,
        HeroDetailComponent,
        HeroDetailComponent2
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }