import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent {
    authorizationFrom: FormGroup = new FormGroup({
        "userName": new FormControl("", Validators.required),
        "userPassword": new FormControl("*****",Validators.required),
    });

    loginClick(event) {
        console.log(this.authorizationFrom.controls['userName'].value);
        console.log(this.authorizationFrom.controls['userPassword'].value);
    }
}