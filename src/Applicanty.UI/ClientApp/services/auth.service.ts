import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class AuthService {
    constructor(private http: HttpClient) { }

    public isAuthenticated() {
        let accessToken = localStorage.getItem('accessToken');

        return accessToken !== undefined && accessToken !== null;
    }

    public login(loginData: any) {
        localStorage.setItem('accessToken', 'here will be token soon');
    }

    public logout() {
        localStorage.removeItem('accessToken');
    }
}