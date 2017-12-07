import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { AuthService } from '../../../../services/auth.service';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent {

    constructor(private authService: AuthService) {
    }

    authorizationFrom: FormGroup = new FormGroup({
        'userName': new FormControl('', Validators.required),
        'userPassword': new FormControl('', Validators.required)
    });

    loginClick(event) {
        if (this.authorizationFrom.valid) {
            this.authService.login(this.authorizationFrom.value);
        }
    }
}