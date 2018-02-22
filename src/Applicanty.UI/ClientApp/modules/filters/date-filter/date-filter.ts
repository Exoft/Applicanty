import { Component, EventEmitter, Input } from "@angular/core";
import { Filter } from "clarity-angular";
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ValidationService } from "../../../services/validation.service";
import { GridFilterCreater } from "../grid-filter-creater";
import { GridFilterItem } from "../grid-filter-item";
import { FilterOperators } from "../../../constants/filter-opertors";

@Component({
    selector: 'clr-datagrid-date-filter',
    templateUrl: './date-filter.html',
    styleUrls: ['./date-filter.scss']
})
export class DateFilter implements Filter<any>, GridFilterCreater {
    public filter: GridFilterItem[] = [];
    @Input() propertyName: string = '';

    private lowerDateLimit;
    private upperDateLimit;

    public dateRangeForm: FormGroup = new FormGroup({
        'lowerDateLimit': new FormControl(null, [this.validationService.endDateValidator]),
        'upperDateLimit': new FormControl(null, [this.validationService.endDateValidator])
    }, this.validationService.dateRangeValidator);

    changes: EventEmitter<any> = new EventEmitter<any>(false);

    constructor(private validationService: ValidationService) { }

    changeDate(event) {
        this.lowerDateLimit = this.dateRangeForm.get('lowerDateLimit');
        this.upperDateLimit = this.dateRangeForm.get('upperDateLimit');
        this.filter = this.createGridFilterItem();

        this.changes.emit(this.filter);
    }

    accepts() {
        if (this.lowerDateLimit)
            return this.lowerDateLimit.value;
    }

    isActive(): boolean {
        if (this.lowerDateLimit || this.upperDateLimit)
            return this.dateRangeForm.valid && (this.lowerDateLimit.value || this.upperDateLimit.value);
        return false;
    }

    createGridFilterItem(): GridFilterItem[] {
        let lst: GridFilterItem[] = [];
        if (this.lowerDateLimit.value)
            lst.push({ field: this.propertyName, value: this.lowerDateLimit.value, operator: FilterOperators.GREATETHENOREQUELTO });

        if (this.upperDateLimit.value)
            lst.push({ field: this.propertyName, value: this.upperDateLimit.value, operator: FilterOperators.LESSTHENOREQUELTO });

        return lst;
    }

}