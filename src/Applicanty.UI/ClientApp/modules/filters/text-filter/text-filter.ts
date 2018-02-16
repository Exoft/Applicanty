﻿import { Component, EventEmitter, Input, OnInit } from "@angular/core";
import { Filter } from "clarity-angular";
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { GridFilterItem } from "../grid-filter-item";
import { FilterOperators } from "../../../constants/filter-opertors";
import { ValidationService } from "../../../services/validation.service";
import { GridFilterCreater } from "../grid-filter-creater";

@Component({
    selector: 'clr-datagrid-text-filter',
    providers: [ValidationService],
    templateUrl: './text-filter.html',
    styleUrls: ['./text-filter.scss']
})
export class TextFilter implements Filter<any>, GridFilterCreater, OnInit{
    private textInput;

    public filter: GridFilterItem;

    @Input() property: string;

    public textFilterForm: FormGroup = new FormGroup({
        'textInput': new FormControl('', [Validators.required]),
    });

    constructor(private validationService: ValidationService) {
    }

    changes: EventEmitter<any> = new EventEmitter<any>(false);

    ngOnInit() {

    }

    changeTextInput(event) {
        this.textInput = this.textFilterForm.get('textInput');
        this.filter = this.CreateGridFilterItem({ field: this.property, operator: FilterOperators.CONTAINS, value: this.textInput.value });
        this.changes.emit(this.textInput ? this.textInput.value : false);
    }

    accepts() {
        if (this.textInput)
            return this.textInput.value;
    }

    isActive(): boolean {
        if (this.textInput)
            return this.textFilterForm.valid && (this.textInput.value);
        return false;
    }

    CreateGridFilterItem(item: GridFilterItem): GridFilterItem {
        let val = item.value;

        return { field: item.field, operator: item.operator, value: val };
    }
}