import { Injectable } from '@angular/core';
import {
    toDataSourceRequestString,
    translateDataSourceResultGroups,
    translateAggregateResults,
    DataResult,
    DataSourceRequestState
} from '@progress/kendo-data-query';
import { GridDataResult, DataStateChangeEvent } from '@progress/kendo-angular-grid';
//import { Observable } from 'rxjs';
import { Observable } from 'rxjs/Rx';
import { Http, Headers, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/zip';
//import { Jsonp } from '@angular/http';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

const CREATE_ACTION = 'create';
const UPDATE_ACTION = 'update';
const DELETE_ACTION = 'destroy';

const itemIndex = (item: any, data: any[]): number => {
    for (let idx = 0; idx < data.length; idx++) {
        if (data[idx].ProductID === item.ProductID) {
            return idx;
        }
    }

    return -1;
};

const cloneData = (data: any[]) => data.map(item => Object.assign({}, item));

@Injectable()
export class GridService extends BehaviorSubject<any[]> {
    private BASE_URL: string = 'api/Products';
    private data: any[] = [];
    private originalData: any[] = [];
    private createdItems: any[] = [];
    private updatedItems: any[] = [];
    private deletedItems: any[] = [];

    constructor(private http: Http) {
        super([]);
    }

    public fetch(state: DataSourceRequestState): Observable<DataResult> {
        let queryStr = `${toDataSourceRequestString(state)}`; // Serialize the state
        let hasGroups = state.group && state.group.length;

        return this.http
            .get(`${this.BASE_URL}?${queryStr}`) // Send the state to the server
            .map(response => response.json())
            .map(({ Data, Total, AggregateResults }) => {// Process the response
                this.data = Data;
                this.originalData = cloneData(Data);

                return (<GridDataResult>{
                    // If there are groups, convert them to a compatible format
                    data: hasGroups ? translateDataSourceResultGroups(Data) : Data,
                    total: Total,
                    // Convert the aggregates if such exist
                    aggregateResult: translateAggregateResults(AggregateResults)
                });
            });
    }

    public create(item: any): void {
        item.ProductID = 0;
        this.createdItems.push(item);        
        this.data.unshift(item);

        //super.next(this.data);
    }

    public update(item: any): void {
        if (!this.isNew(item)) {
            let index = itemIndex(item, this.updatedItems);
            if (index !== -1) {
                this.updatedItems.splice(index, 1, item);
            } else {
                this.updatedItems.push(item);
            }
        } else {
            let index = itemIndex(item, this.createdItems);
            this.createdItems.splice(index, 1, item);
        }
    }

    public remove(item: any): void {
        let index = itemIndex(item, this.data);
        this.data.splice(index, 1);

        index = itemIndex(item, this.createdItems);
        if (index >= 0) {
            this.createdItems.splice(index, 1);
        } else {
            this.deletedItems.push(item);
        }

        index = itemIndex(item, this.updatedItems);
        if (index >= 0) {
            this.updatedItems.splice(index, 1);
        }

        //super.next(this.data);
    }

    public isNew(item: any): boolean {
        return !item.ProductID;
    }

    public hasChanges(): boolean {
        return Boolean(this.deletedItems.length || this.updatedItems.length || this.createdItems.length);
    }

    public saveChanges(): void {
        if (!this.hasChanges()) {
            return;
        }

        let completed = [];
        if (this.createdItems.length) {
            completed.push(this.edit(CREATE_ACTION, this.createdItems));
        }

        if (this.updatedItems.length) {
            completed.push(this.edit(UPDATE_ACTION, this.updatedItems));
        }

        if (this.deletedItems.length) {
            completed.push(this.edit(DELETE_ACTION, this.deletedItems));
        }

        //this.reset();

        console.log(new Date().toISOString());
        Observable.zip(...completed).subscribe(() => {
            console.log(new Date().toISOString());
            //this.read();
        });
    }

    public cancelChanges(): void {
        this.reset();

        this.data.push(...this.originalData);
        this.originalData = cloneData(this.originalData);
        super.next(this.data);
    }

    public assignValues(target: any, source: any): void {
        Object.assign(target, source);
    }

    private reset() {
        //this.data = [];
        this.data.length = 0;
        this.createdItems = [];
        this.updatedItems = [];
        this.deletedItems = [];
    }

    private edit(action: string = "", data: any): Observable<any[]> {
        let method =
            action === CREATE_ACTION ? 'post' :
                action === UPDATE_ACTION ? 'put' :
                    action === DELETE_ACTION ? 'delete' :
                        null;

        return this.http[method](this.BASE_URL, data)
            .map((response: any) => response.json());

        //.map(({ Data, Total, AggregateResults }) => {// Process the response
        //    console.log(Data, Total);
        //    this.originalData = cloneData(Data);

        //    return (<GridDataResult>{
        //        // If there are groups, convert them to a compatible format
        //        data: hasGroups ? translateDataSourceResultGroups(Data) : Data,
        //        total: Total,
        //        // Convert the aggregates if such exist
        //        aggregateResult: translateAggregateResults(AggregateResults)

        //    });
        //});
    }
}
