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
        this.http.post('http://localhost:8000/api/Auth', loginData).subscribe(data => {
            console.log(data);
            localStorage.setItem('accessToken', 'here will be token soon');
        });
    }

    public logout() {
        localStorage.removeItem('accessToken');
    }
}