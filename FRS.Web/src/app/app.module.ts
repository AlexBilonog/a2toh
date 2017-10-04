import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppRoutingModule } from './app-routing.module';
import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { GridModule } from '@progress/kendo-angular-grid';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { JsonpModule } from '@angular/http';
import { GridService } from './common/grid.service';

import { AppComponent } from './app.component';
import { ProductsComponent } from './products/products.component';
import { DropDownListFilterComponent } from './products/dropdownlist-filter.component';
import { FormBuilder } from './index';

@NgModule({
    declarations: [
        AppComponent,
        ProductsComponent,
        DropDownListFilterComponent
    ],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        FormsModule,
        ReactiveFormsModule,
        AppRoutingModule,
        HttpModule,
        ButtonsModule,
        GridModule,
        DropDownsModule,
        JsonpModule
    ],
    providers: [
        GridService,
        FormBuilder
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
