import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { AuthService } from '../../../services/auth.service';

@Injectable()
export class VacanciesDataService {
    constructor(private http: HttpClient,
        private authService: AuthService) {
    }

    public getVacancies() {
        return this.http.get('http://localhost:8000/api/vacancy', { headers: this.authService.getAuthenticationHeader() });
    }

    public getVacancy(vacancyId: any) {
        return this.http.get('http://localhost:8000/api/vacancy/' + vacancyId, { headers: this.authService.getAuthenticationHeader() });
    }

    public createVacancy(vacancy: any) {
        return this.http.post('http://localhost:8000/api/vacancy', vacancy, { headers: this.authService.getAuthenticationHeader() });
    }

    public updateVacancy(vacancy: any) {
        return this.http.put('http://localhost:8000/api/vacancy', vacancy, { headers: this.authService.getAuthenticationHeader() });
    }

    public deleteVacancy(vacancyId: any) {
        return this.http.delete('http://localhost:8000/api/vacancy/' + vacancyId, { headers: this.authService.getAuthenticationHeader() });
    }
}