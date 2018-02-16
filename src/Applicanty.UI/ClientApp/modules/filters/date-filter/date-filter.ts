import { Component, EventEmitter } from "@angular/core";
import { Filter } from "clarity-angular";
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ValidationService } from "../../../services/validation.service";

@Component({
    selector: 'clr-datagrid-date-filter',
    providers: [ValidationService],
    templateUrl: './date-filter.html',
    styleUrls: ['./date-filter.scss']
})
export class DateFilter implements Filter<any>{
    private startDate;

    public dateRangeForm: FormGroup = new FormGroup({
        'startDate': new FormControl(null, [this.validationService.endDateValidator]),
        'endDate': new FormControl(null, [this.validationService.endDateValidator])
    });

    changes: EventEmitter<any> = new EventEmitter<any>(false);

    constructor(private validationService: ValidationService) { }

    changeDate(event) {
        this.startDate = this.dateRangeForm.get('startDate');
        console.log(this.startDate ? this.startDate.value : 'none');
        this.changes.emit(this.startDate.value);
    }

    accepts(item: Date) {
        if (this.startDate)
            //    return true ? this.val.value : false;//this.nbExperiences === 0 || this.selectedExperiences[item];
            return this.startDate.value;
    }

    isActive(): boolean {
        //return this.nbExperiences > 0;
        if (this.startDate)
            return this.dateRangeForm.valid && (this.startDate.value);
        return false;
    }

}