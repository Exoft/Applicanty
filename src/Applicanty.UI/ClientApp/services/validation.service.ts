import { Injectable, Inject } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { DecimalPipe } from '@angular/common';
import { AbstractControl, ValidationErrors } from '@angular/forms';

@Injectable()
export class ValidationService {
    private config = {};

    private static http: any;

    private static emailRegex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/gm;

    constructor(private httpClient: HttpClient) {
        ValidationService.http = httpClient;

        this.config = {
            'required': 'This field is required',
            'invalidEmail': 'Entered value is not valid email address',
            'passwordsDoNotMatch': 'Password do not match',
            'invalidEndDate': 'End date can not be later than today',
            'invalidTechnologiesCount': 'Number of technologies can not be less two',
            'invalidLowerDateLimit': 'Lower date limit  cannot be later than upper date limit'
        };
    }

    public getValidatorErrorMessage(control: any) {
        if (control && control !== null) {
            for (let propertyName in control.errors) {
                if (control.errors.hasOwnProperty(propertyName)) {
                    return this.config[propertyName];
                }
            }
        }

        return null;
    }

    public emailValidator(control) {
        if (!control.value || control.value === null)
            return null;

        if (control.value.match(ValidationService.emailRegex)) {
            return null;
        } else {
            return { 'invalidEmail': true };
        }
    }

    public confirmPasswordValidator(formGroup) {
        if (!formGroup.get('password').value || !formGroup.get('confirmPassword').value
            || formGroup.get('password').value === null || formGroup.get('confirmPassword').value === null)
            return null;

        if (formGroup.get('password').value === formGroup.get('confirmPassword').value) {
            return null;
        } else {
            return { 'passwordsDoNotMatch': true };
        }
    }

    public endDateValidator(control) {
        if (!control.value || control.value === null)
            return null;

        let endDate = new Date(control.value);
        if (new Date() < endDate) {
            return null;
        } else {
            return { 'invalidEndDate': true }
        }
    }

    public technologiesValidator(control) {
        if (!control.value || control.value === null)
            return null;

        if (control.value.length > 2) {
            return null;
        } else {
            return { 'invalidTechnologiesCount': true };
        }
    }

    public dateRangeValidator(formGroup) {
        if (!formGroup.get('lowerDateLimit').value || !formGroup.get('upperDateLimit').value
            || formGroup.get('lowerDateLimit').value === null || formGroup.get('upperDateLimit').value === null)
            return null;

        if (new Date(formGroup.get('lowerDateLimit').value) < new Date(formGroup.get('upperDateLimit').value)) {
            return null;
        } else {
            return { 'invalidLowerDateLimit': true };
        }
    }
}
