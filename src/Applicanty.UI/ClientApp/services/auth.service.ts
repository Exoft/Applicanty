import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from "@angular/router";
import { NotificationService } from "../services/notification.service";
import { NotificationType } from "../enums/notification-type";
import { NotificationMessage } from "../constants/notification-message";

@Injectable()
export class AuthService {
    constructor(private http: HttpClient,
        private router: Router,
        private notificationService: NotificationService) { }

    public isAuthenticated() {
        let accessToken = localStorage.getItem('accessToken');

        return accessToken !== 'undefined' && accessToken !== undefined && accessToken !== null;
    }

    public signIn(loginData: any) {
        let that = this;

        that.http.post('http://localhost:8000/user/login', loginData).subscribe(
            data => {
                localStorage.setItem('accessToken', data['access_token']);

                that.router.navigate(['dashboard']);
            },
            error => {
                if (error.status == 403) {
                    that.notificationService.notify(NotificationType.Error, NotificationMessage.VACANCYDETAILSLOADERROR);
                }
            });
    }

    public signOut() {
        localStorage.removeItem('accessToken');

        this.router.navigate(['signin']);
    }

    public getAuthenticationHeader() {
        return new HttpHeaders().set('Authorization', `Bearer ${localStorage.getItem('accessToken')}`);
    }

    public signUp(userData: any, signUpErrorCallback: any) {
        let that = this;

        that.http.post('http://localhost:8000/user/register', userData).subscribe(
            data => {
                that.router.navigate(['emailverification'], { queryParams: { email: userData.email } });
            },
            error => {
                if (error.error.identityErrors && error.error.identityErrors.length && signUpErrorCallback) {
                    signUpErrorCallback(error.error.identityErrors);
                }
            });
    }

    public confirmEmail(email: any, token: any) {
        return this.http.post('http://localhost:8000/user/confirmemail?email=' + email + '&token=' + token, {});
    }
}