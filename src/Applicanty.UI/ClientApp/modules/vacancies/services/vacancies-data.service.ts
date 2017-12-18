﻿import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import { AuthService } from '../../../services/auth.service';

@Injectable()
export class VacanciesDataService {
    constructor(private http: HttpClient,
        private authService: AuthService) {
    }

    public getVacancies(): Observable<any> {
        return this.http.get('http://localhost:8000/api/vacancy', { headers: this.authService.getAuthenticationHeader() });
    }

    public getVacancy(vacancyId: any): Observable<any> {
        return this.http.get('http://localhost:8000/api/vacancy/' + vacancyId, { headers: this.authService.getAuthenticationHeader() });
    }

    public createVacancy(vacancy: any): Observable<any> {
        return this.http.post('http://localhost:8000/api/vacancy', vacancy, { headers: this.authService.getAuthenticationHeader() });
    }

    public updateVacancy(vacancy: any): Observable<any> {
        return this.http.put('http://localhost:8000/api/vacancy', vacancy, { headers: this.authService.getAuthenticationHeader() });
    }

    public deleteVacancy(vacancyId: any): Observable<any> {
        return this.http.delete('http://localhost:8000/api/vacancy/' + vacancyId, { headers: this.authService.getAuthenticationHeader() });
    }
}