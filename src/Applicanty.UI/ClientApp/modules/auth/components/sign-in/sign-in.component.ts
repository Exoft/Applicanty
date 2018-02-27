import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from "@angular/router";

import { AuthService } from '../../../../services/auth.service';
import { ValidationService } from "../../../../services/validation.service";
import { NotificationType } from "../../../../enums/notification-type";
import { NotificationMessage } from "../../../../constants/notification-message";
import { NotificationService } from "../../../../services/notification.service";

@Component({
    templateUrl: './sign-in.component.html',
    styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent {
    public validateSigIn: boolean = false;
    public textButtonSignIn: string = "Sign in";

    constructor(private authService: AuthService,
        private router: Router,
        public validationService: ValidationService,
        private notificationService: NotificationService) {
    }

    authorizationFrom: FormGroup = new FormGroup({
        'email': new FormControl('', Validators.required),
        'password': new FormControl('', Validators.required)
    });

    signIn(event) {
        let that = this;
        if (this.authorizationFrom.valid) {
            this.validateSigIn = true;
            this.textButtonSignIn = "";
            this.authService.signIn(this.authorizationFrom.value).subscribe(
                data => {
                    localStorage.setItem('accessToken', data['access_token']);

                    that.router.navigate(['dashboard']);
                },
                error => {
                    if (error.status === 403 || error.status === 400) {
                        debugger;
                        this.validateSigIn = false;
                        this.textButtonSignIn = "Sign in";
                        that.notificationService.notify(NotificationType.Error, NotificationMessage.VACANCYDETAILSLOADERROR);
                    }
                });;
        }
    }

    signUp(event) {
        this.router.navigate(['signup']);
    }
}