import { Injectable, Inject, OnDestroy } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { DecimalPipe } from '@angular/common';
import { AbstractControl, ValidationErrors } from '@angular/forms';
import { TranslateService } from "@ngx-translate/core";

@Injectable()
export class ValidationService implements OnDestroy {
    private config = {};

    private static http: any;

    private static emailRegex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/gm;

    private langChangeSub: any;

    constructor(private httpClient: HttpClient,
        private translateService: TranslateService) {
        ValidationService.http = httpClient;

        let that = this;

        that.loadMessages();

        translateService.onLangChange.subscribe(() => {
            that.loadMessages();
        });
    }

    ngOnDestroy() {
        if (this.langChangeSub) {
            this.langChangeSub.unsubscribe();
        }
    }

    private loadMessages() {
        let that = this;

        that.translateService.get('validation').subscribe(res => {
            that.config = {
                'required': res['required'],
                'min': res['min'],
                'invalidEmail': res['invalidEmail'],
                'passwordsDoNotMatch': res['passwordsDoNotMatch'],
                'invalidTechnologiesCount': res['invalidTechnologiesCount'],
                'invalidLowerDateLimit': res['invalidLowerDateLimit'],
                'invalidLowerAgeLimit': res['invalidLowerAgeLimit']
            };
        });
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

    public ageRangeValidator(formGroup) {
        if (!formGroup.get('lowerAgeLimit').value || !formGroup.get('upperAgeLimit').value
            || formGroup.get('lowerAgeLimit').value === null || formGroup.get('upperAgeLimit').value === null)
            return null;

        if (new Date(formGroup.get('lowerAgeLimit').value) < new Date(formGroup.get('upperAgeLimit').value)) {
            return null;
        } else {
            return { 'invalidLowerAgeLimit': true };
        }
    }
}
