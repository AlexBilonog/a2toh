import { Observable, Component, OnInit, Validators, FormBuilder, GridDataResult, State, process } from '../index';
import { GridService } from '../shared/grid.service';
import { Product } from './product';

@Component({
    moduleId: module.id,
    templateUrl: 'products.component.html'
})
export class ProductsComponent implements OnInit {
    public gridView: Observable<GridDataResult>;
    public gridState: State = { sort: [], skip: 0, take: 10 };

    constructor(private formBuilder: FormBuilder, public gridService: GridService) {
        this.createFormGroup = this.createFormGroup.bind(this); // TODO: do automatically
    }

    public ngOnInit() {
        this.gridView = this.gridService.map(data => process(data, this.gridState)); // TODO: move on server
        this.gridService.read();
    }

    public onStateChange(state: State) {
        this.gridState = state;
        this.gridService.read();
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
