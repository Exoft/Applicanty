import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { AuthService } from '../../../../services/auth.service';

@Component({
    selector: 'signUp',
    templateUrl: './sign-up.component.html',
    styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent {

    public identityErrors: any;

    static signUpComponentInstance: any;

    constructor(private authService: AuthService) {
        SignUpComponent.signUpComponentInstance = this;
    }

    registrationForm: FormGroup = new FormGroup({
        'email': new FormControl('', Validators.required),
        'password': new FormControl('', Validators.required),
        'confirmpassword': new FormControl('', Validators.required)
    });

    signUp(event) {
        SignUpComponent.signUpComponentInstance.identityErrors = undefined;

        if (this.registrationForm.valid) {
            this.authService.signUp(this.registrationForm.value, this.onSignUpErrorOccured);
        }
    }

    onSignUpErrorOccured(errors: any[]) {
        if (errors.length) {
            SignUpComponent.signUpComponentInstance.identityErrors = errors.map(item => item.description).join('<br>');
        }
    }
}