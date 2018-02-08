import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';

import { AuthService } from '../../../services/auth.service';

@Injectable()
export class VacanciesDataService {
    constructor(private http: HttpClient,
        private authService: AuthService) {
    }

    public getVacancies(skip: number = 0, take: number = 10, sortBy: string = '', sortDir: string = '', statusType: number = 1): Observable<any> {
        return this.http.get(`http://localhost:8000/vacancy?skip=${skip}&take=${take}&sortField=${sortBy}&sortDir=${sortDir}&statusType=${statusType}`, { headers: this.authService.getAuthenticationHeader() });
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

    public changeVacanciesStatus(ids: number[], status: any): Observable<any> {
        return this.http.post('http://localhost:8000/vacancy/changeStatus?status=' + status, ids, { headers: this.authService.getAuthenticationHeader() });
    }

    public getTechnologies(): Observable<any> {
        return this.http.get('http://localhost:8000/technology', { headers: this.authService.getAuthenticationHeader() });
    }

    public getVacancyStagesCount(id: number): Observable<any> {
        return this.http.get(`http://localhost:8000/vacancy/countVacancyStageCandidates?id=${id}`, { headers: this.authService.getAuthenticationHeader() })
    }
}