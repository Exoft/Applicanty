import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from "@angular/router";

@Injectable()
export class AuthService {
    constructor(private http: HttpClient,
        private router: Router) { }

    public isAuthenticated() {
        let accessToken = localStorage.getItem('accessToken');

        return accessToken !== undefined && accessToken !== null;
    }

    public login(loginData: any) {
        let that = this;

        that.http.post('http://localhost:8000/api/Auth', loginData).subscribe(data => {
            localStorage.setItem('accessToken', data['access_token']);

            that.router.navigate(['profile']);
        });
    }

    public logout() {
        localStorage.removeItem('accessToken');

        this.router.navigate(['login']);
    }
}