import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from "@angular/router";

import { AuthService } from '../../../../services/auth.service';
import { ValidationService } from "../../../../services/validation.service";

@Component({
    templateUrl: './sign-in.component.html',
    styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent {
    public validateSigIn: boolean = false;
    public textButtonSignIn: string = "Sign in";

    constructor(private authService: AuthService,
        private router: Router,
        public validationService: ValidationService) {
    }

    authorizationFrom: FormGroup = new FormGroup({
        'email': new FormControl('', Validators.required),
        'password': new FormControl('', Validators.required)
    });

    signIn(event) {
        if (this.authorizationFrom.valid) {
            this.validateSigIn = true;
            this.textButtonSignIn = "";
            this.authService.signIn(this.authorizationFrom.value);
        }
    }

    signUp(event) {
        this.router.navigate(['signup']);
    }
}