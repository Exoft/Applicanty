﻿import { Component, EventEmitter, Input } from '@angular/core';
import { Filter } from '@clr/angular';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ValidationService } from '../../../services/validation.service';
import { GridFilterCreater } from '../grid-filter-creater';
import { GridFilterItem } from '../grid-filter-item';
import { FilterOperators } from '../../../constants/filter-opertors';

@Component({
    selector: 'apl-clr-datagrid-age-filter',
    templateUrl: './age-filter.html',
    styleUrls: ['./age-filter.scss']
})
export class AgeFilterComponent implements GridFilterCreater {
    public filter: GridFilterItem[] = [];
    @Input() propertyName = '';

    private lowerAgeLimit;
    private upperAgeLimit;

    public ageRangeForm: FormGroup = new FormGroup({
        'lowerAgeLimit': new FormControl(null, [Validators.min(17)]),
        'upperAgeLimit': new FormControl(null, [Validators.min(17)])
    }, this.validationService.ageRangeValidator);

    changes: EventEmitter<any> = new EventEmitter<any>(false);

    constructor(public validationService: ValidationService) { }

    changeAge(event) {
        this.lowerAgeLimit = this.ageRangeForm.get('lowerAgeLimit');
        this.upperAgeLimit = this.ageRangeForm.get('upperAgeLimit');
        this.filter = this.createGridFilterItem();

        this.changes.emit(this.filter);
    }

    accepts() {
        if (this.lowerAgeLimit) {
            return this.lowerAgeLimit.value;
        }
    }

    isActive(): boolean {
        if (this.lowerAgeLimit || this.upperAgeLimit) {
            return this.ageRangeForm.valid && (this.lowerAgeLimit.value || this.upperAgeLimit.value);
        }
        return false;
    }

    createGridFilterItem(): GridFilterItem[] {
        const lst: GridFilterItem[] = [];
        if (this.lowerAgeLimit.value) {
            lst.push({ field: this.propertyName, value:
                 this.transformAgeToBirthDate(this.lowerAgeLimit.value), operator: FilterOperators.LESSTHENOREQUELTO });
        }

        if (this.upperAgeLimit.value) {
            lst.push({ field: this.propertyName, value:
                 this.transformAgeToBirthDate(this.upperAgeLimit.value), operator: FilterOperators.GREATETHENOREQUELTO });
        }

        return lst;
    }

    transformAgeToBirthDate(value: number): string {
        const today = new Date();
        const birthdate = new Date(today.setFullYear(today.getFullYear() - value - 1, today.getMonth(), today.getDate()));

        return birthdate.toLocaleDateString();
    }
}
