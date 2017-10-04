import { Component, Input } from '@angular/core';
import { CompositeFilterDescriptor } from '@progress/kendo-data-query';
import { FilterService, BaseFilterCellComponent } from '@progress/kendo-angular-grid';

@Component({
    selector: 'my-dropdown-filter',
    template: `
<ng-template kendoGridFilterCellTemplate let-filter>
    <kendo-dropdownlist 
      
      [data]="data"
      (valueChange)="onChange($event)" 
      [defaultItem]="defaultItem"
      [value]="selectedValue" 
      [valuePrimitive]="true"
      [textField]="textField"
      [valueField]="valueField">
    </kendo-dropdownlist>
</ng-template>`
})
/*[filter]="filter"
        <ng-template kendoGridFilterCellTemplate let-filter>
        <my-dropdown-filter [filter]="filter"
                            [data]="categories"
                            textField="Name"
                            valueField="Id">
        </my-dropdown-filter>
    </ng-template>
    <ng-template kendoGridCellTemplate let-dataItem>{{category(dataItem.CategoryId)?.Name}}</ng-template>
    <ng-template kendoGridEditTemplate let-dataItem="dataItem" let-formGroup="formGroup">
        <kendo-dropdownlist [data]="categories" textField="Name" valueField="Id"
                            [valuePrimitive]="true" [formControl]="formGroup.get('CategoryId')">
        </kendo-dropdownlist>
    </ng-template>

*/
export class DropDownListFilterComponent extends BaseFilterCellComponent {

    public get selectedValue(): any {
        const filter = this.filterByField(this.valueField);
        return filter ? filter.value : null;
    }

    @Input() public filter: CompositeFilterDescriptor;
    @Input() public data: any[];
    @Input() public textField: string;
    @Input() public valueField: string;

    public get defaultItem(): any {
        return {
            [this.textField]: "Select item...",
            [this.valueField]: null
        };
    }

    constructor(filterService: FilterService) {
        super(filterService);
    }

    public onChange(value: any): void {
        this.applyFilter(
            value === null ? // value of the default item
                this.removeFilter(this.valueField) : // remove the filter 
                this.updateFilter({ // add a filter for the field with the value
                    field: this.valueField,
                    operator: "eq",
                    value: value
                })
        ); // update the root filter
    }
}
