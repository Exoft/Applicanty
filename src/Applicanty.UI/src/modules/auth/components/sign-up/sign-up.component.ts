import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

import { AuthService } from '../../../../services/auth.service';
import { ValidationService } from '../../../../services/validation.service';

import { environment } from '../../../../environments/environment';

@Component({
    selector: 'apl-sign-up-component',
    templateUrl: './sign-up.component.html',
    styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent implements OnInit {
    static signUpComponentInstance: any;

    public identityErrors: any;
    public registrationForm: any;

    public uiModulesVersion = '';
    public apiVersion = '';

    constructor(private authService: AuthService,
        private router: Router,
        public validationService: ValidationService,
        private http: HttpClient) {
        SignUpComponent.signUpComponentInstance = this;

        this.registrationForm = new FormGroup({
            'email': new FormControl('', [Validators.required, this.validationService.emailValidator]),
            'password': new FormGroup({
                'password': new FormControl('', Validators.required),
                'confirmPassword': new FormControl('', Validators.required)
            }, this.validationService.confirmPasswordValidator)
        });
    }

    ngOnInit() {
        this.uiModulesVersion = environment.version;

        this.http.get<{ version: string }>(`${environment.apiRootUrl}version`)
            .subscribe(result => {
                this.apiVersion = result.version;
            });
    }

    public signUp(event) {
        SignUpComponent.signUpComponentInstance.identityErrors = undefined;

        if (this.registrationForm.valid) {
            const formData = {
                email: this.registrationForm.value.email,
                password: this.registrationForm.value.password.password
            };

            this.authService.signUp(formData, this.onSignUpErrorOccured);
        }
    }

    public onSignUpErrorOccured(errors: any[]) {
        if (errors.length) {
            SignUpComponent.signUpComponentInstance.identityErrors = errors.map(item => item.description).join('<br>');
        }
    }
}
