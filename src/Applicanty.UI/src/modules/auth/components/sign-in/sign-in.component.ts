import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

import { AuthService } from '../../../../services/auth.service';
import { ValidationService } from '../../../../services/validation.service';
import { NotificationType } from '../../../../enums/notification-type';
import { NotificationService } from '../../../../services/notification.service';

import { environment } from '../../../../environments/environment';

@Component({
    templateUrl: './sign-in.component.html',
    styleUrls: ['./sign-in.component.scss']
})
export class SignInComponent implements OnInit {
    public validateSigIn = false;
    public textButtonSignIn = 'Sign in';

    public uiModulesVersion = '';
    public apiVersion = '';

    authorizationFrom: FormGroup = new FormGroup({
        'email': new FormControl('', Validators.required),
        'password': new FormControl('', Validators.required)
    });

    constructor(private authService: AuthService,
        private router: Router,
        public validationService: ValidationService,
        private notificationService: NotificationService,
        private http: HttpClient) {
    }

    ngOnInit() {
        this.uiModulesVersion = environment.version;

        this.http.get<{ version: string }>(`${environment.apiRootUrl}version`)
            .subscribe(result => {
                this.apiVersion = result.version;
            });
    }

    signIn(event) {
        if (this.authorizationFrom.valid) {
            this.validateSigIn = true;
            this.textButtonSignIn = '';
            this.authService.signIn(this.authorizationFrom.value).subscribe(
                data => {
                    localStorage.setItem('accessToken', data['access_token']);

                    this.router.navigate(['dashboard']);
                },
                error => {
                    if (error.status === 400) {
                        this.notificationService.notify(NotificationType.Error, 'signInError');
                    } if (error.status === 403) {
                        this.notificationService.notify(NotificationType.Error, 'forbiddenError');
                    }
                    this.validateSigIn = false;
                    this.textButtonSignIn = 'Sign in';
                });
        }
    }

    signUp(event) {
        this.router.navigate(['signup']);
    }
}
