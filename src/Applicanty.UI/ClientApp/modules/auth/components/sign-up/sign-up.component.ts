import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from "@angular/router";

import { AuthService } from '../../../../services/auth.service';
import { ValidationService } from "../../../../services/validation.service";

@Component({
    selector: 'signUp',
    templateUrl: './sign-up.component.html',
    styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent {

    public identityErrors: any;

    static signUpComponentInstance: any;

    constructor(private authService: AuthService,
                private router: Router,
        public validationService: ValidationService) {
        SignUpComponent.signUpComponentInstance = this;
    }

    registrationForm: FormGroup = new FormGroup({
        'email': new FormControl('', Validators.required),
        'password': new FormControl('', Validators.required),
        'confirmPassword': new FormControl('', Validators.required)
    });

    signUp(event) {
        SignUpComponent.signUpComponentInstance.identityErrors = undefined;

        if (this.registrationForm.valid) {
            this.authService.signUp(this.registrationForm.value, this.onSignUpErrorOccured);
        }
        this.router.navigate(['profile']);
    }

    onSignUpErrorOccured(errors: any[]) {
        if (errors.length) {
            SignUpComponent.signUpComponentInstance.identityErrors = errors.map(item => item.description).join('<br>');
        }
    }
}