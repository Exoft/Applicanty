import { Component, EventEmitter, Input } from "@angular/core";
import { Filter } from "clarity-angular";
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ValidationService } from "../../../services/validation.service";
import { GridFilterCreater } from "../grid-filter-creater";
import { GridFilterItem } from "../grid-filter-item";
import { FilterOperators } from "../../../constants/filter-opertors";

@Component({
    selector: 'clr-datagrid-date-filter',
    providers: [ValidationService],
    templateUrl: './date-filter.html',
    styleUrls: ['./date-filter.scss']
})
export class DateFilter implements Filter<any>, GridFilterCreater{
    public filter: GridFilterItem[];
    @Input() propertyName: string;
    filterOperator: FilterOperators = FilterOperators.GREATETHENOREQUELTO;

    private startDate;
    private endDate;

    public dateRangeForm: FormGroup = new FormGroup({
        'startDate': new FormControl(null, [this.validationService.endDateValidator]),
        'endDate': new FormControl(null, [this.validationService.endDateValidator])
    });

    changes: EventEmitter<any> = new EventEmitter<any>(false);

    constructor(private validationService: ValidationService) { }

    changeDate(event) {
        this.startDate = this.dateRangeForm.get('startDate');
        this.endDate = this.dateRangeForm.get('endDate');
        this.filter = this.CreateGridFilterItem();

        this.changes.emit(this.filter);
    }

    accepts(item: Date) {
        if (this.startDate)
            //    return true ? this.val.value : false;//this.nbExperiences === 0 || this.selectedExperiences[item];
            return this.startDate.value;
    }

    isActive(): boolean {
        //return this.nbExperiences > 0;
        if (this.startDate || this.endDate)
            return this.dateRangeForm.valid && (this.startDate.value || this.endDate);
        return false;
    }

    CreateGridFilterItem(): GridFilterItem[] {
        let lst: GridFilterItem[] = [];
        if (this.startDate.value)
            lst.push({ field: this.propertyName, value: this.startDate.value, operator: FilterOperators.GREATETHENOREQUELTO });

        if (this.endDate.value)
            lst.push({ field: this.propertyName, value: this.endDate.value, operator: FilterOperators.LESSTHENOREQUELTO });

        return lst;
    }

}