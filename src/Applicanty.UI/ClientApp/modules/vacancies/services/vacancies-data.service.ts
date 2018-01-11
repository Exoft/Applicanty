import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';

import { AuthService } from '../../../services/auth.service';

@Injectable()
export class VacanciesDataService {
    constructor(private http: HttpClient,
        private authService: AuthService) {
    }

    public getVacancies(skip: number = 0, take: number = 10): Observable<any> {
        return this.http.get(`http://localhost:8000/vacancy?skip=${skip}&take=${take}`, { headers: this.authService.getAuthenticationHeader() });
    }

    public getVacancy(vacancyId: any): Observable<any> {
        return this.http.get(`http://localhost:8000/vacancy/${vacancyId}`, { headers: this.authService.getAuthenticationHeader() });
    }

    public createVacancy(vacancy: any): Observable<any> {
        return this.http.post('http://localhost:8000/vacancy', vacancy, { headers: this.authService.getAuthenticationHeader() });
    }

    public updateVacancy(vacancy: any): Observable<any> {
        return this.http.put('http://localhost:8000/vacancy', vacancy, { headers: this.authService.getAuthenticationHeader() });
    }

    public deleteVacancy(vacancies: number[]): Observable<any> {
        return this.http.delete('http://localhost:8000/vacancy/' + vacancies, { headers: this.authService.getAuthenticationHeader() });
    }
}