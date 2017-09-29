import { Component, /*Observable,*/ OnInit, Validators, FormBuilder, GridDataResult, State } from '../index';
import { GridService } from '../common/grid.service';
import { Product } from './product';

@Component({
    moduleId: module.id,
    templateUrl: 'products.component.html'
})
export class ProductsComponent implements OnInit {
    public gridView: GridDataResult; // Observable<GridDataResult>;
    public gridState: State = { skip: 0, take: 10 };

    constructor(private formBuilder: FormBuilder, public gridService: GridService) {
        this.createFormGroup = this.createFormGroup.bind(this); // TODO: do automatically
    }

    public ngOnInit() {
        this.onStateChange(this.gridState);
    }

    public onStateChange(state: State) {
        this.gridState = state;
        this.gridService.fetch(this.gridState).subscribe(r => this.gridView = r);
    }

    public createFormGroup(args: any) {
        let item: Product = args.isNew ? new Product() : args.dataItem;

        var formGroup = this.formBuilder.group({
            ProductID: item.ProductID,
            ProductName: [item.ProductName, Validators.required],
            UnitPrice: item.UnitPrice,
            UnitsInStock: [item.UnitsInStock, Validators.compose([Validators.required, Validators.pattern('^[0-9]{1,3}')])],
            Discontinued: item.Discontinued
        });

        return formGroup;
    }
}
