import * as rx from 'rxjs/Rx';
import * as core from '@angular/core';
import * as forms from '@angular/forms';
import * as grid from '@progress/kendo-angular-grid';
import * as query from '@progress/kendo-data-query';

//import { Observable } from 'rxjs/Rx';
//import { Component, OnInit } from '@angular/core';
//import { Validators, FormBuilder } from '@angular/forms';
//import { GridDataResult } from '@progress/kendo-angular-grid';
//import { State, process } from '@progress/kendo-data-query';

export class Observable<T> extends rx.Observable<T> { }

export var Component = core.Component;
//export var Component = function (component: core.Component) {
//    component.moduleId = module.id;
//    console.log(arguments);
//    debugger;
//    return core.Component(component);
//}
export interface OnInit extends core.OnInit { }

export class Validators extends forms.Validators { }
export class FormBuilder extends forms.FormBuilder { }

export interface GridDataResult extends grid.GridDataResult { }

export interface State extends query.State { }
//export var process = query.process;

// Actually not needed, but not include FormBuilder into providers
exports.Observable = rx.Observable;

exports.Component = core.Component;
//exports.OnInit = core.OnInit;

exports.Validators = forms.Validators;
exports.FormBuilder = forms.FormBuilder;

//exports.GridDataResult = grid.GridDataResult;

//exports.State = query.State;
//exports.process = query.process;
