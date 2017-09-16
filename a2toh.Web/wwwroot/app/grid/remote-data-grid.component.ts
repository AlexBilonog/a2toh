import { Observable } from 'rxjs/Rx';
import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';

import { GridDataResult } from '@progress/kendo-angular-grid';
import { State, process } from '@progress/kendo-data-query';

import { products } from './products';
import { Product } from './model';
import { EditService } from './edit.service';

@Component({
    moduleId: module.id,
    selector: 'my-app',
    templateUrl: 'remote-data-grid.html',
    //, styleUrls: ['../../../node_modules/@progress/kendo-theme-default/dist/all.css']
})
export class RemoteDataGridComponent implements OnInit {
    public view: Observable<GridDataResult>;
    public gridState: State = {
        sort: [],
        skip: 0,
        take: 10
    };

    public changes: any = {};

    constructor(private formBuilder: FormBuilder, public editService: EditService) {
        this.createFormGroup = this.createFormGroup.bind(this);
    }

    public ngOnInit(): void {
        this.view = this.editService.map(data => process(data, this.gridState));

        this.editService.read();
    }

    public onStateChange(state: State) {
        this.gridState = state;

        this.editService.read();
    }

    public createFormGroup(args: any) {
        const item = args.isNew ? new Product() : args.dataItem;

        var formGroup = this.formBuilder.group({
            'ProductID': item.ProductID,
            'ProductName': [item.ProductName, Validators.required],
            'UnitPrice': item.UnitPrice,
            'UnitsInStock': [item.UnitsInStock, Validators.compose([Validators.required, Validators.pattern('^[0-9]{1,3}')])],
            'Discontinued': item.Discontinued
        });

        return formGroup;
    }
}
