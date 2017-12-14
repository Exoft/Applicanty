import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from "@angular/router";

@Injectable()
export class AuthService {
    constructor(private http: HttpClient,
        private router: Router) { }

    public isAuthenticated() {
        let accessToken = localStorage.getItem('accessToken');

        return accessToken !== 'undefined' && accessToken !== undefined && accessToken !== null;
    }

    public login(loginData: any) {
        let that = this;
        that.http.post('http://localhost:8000/api/auth', loginData).subscribe(data => {
            localStorage.setItem('accessToken', data['access_token']);

            that.router.navigate(['vacancies']);
        });
    }

    public logout() {
        localStorage.removeItem('accessToken');

        this.router.navigate(['login']);
    }

    public getAuthenticationHeader() {
        return new HttpHeaders().set('Authorization', `Bearer ${localStorage.getItem('accessToken')}`);
    }
}