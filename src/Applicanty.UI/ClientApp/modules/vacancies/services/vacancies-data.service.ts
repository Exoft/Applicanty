import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';

import { AuthService } from '../../../services/auth.service';
import { GridRequest } from "../../../services/grid-request";

@Injectable()
export class VacanciesDataService {
    constructor(private http: HttpClient,
        private authService: AuthService) {
    }

    public getVacancies(statusType: number, gridRequest: GridRequest): Observable<any> {
        return this.http.post(`http://localhost:8000/vacancy/getAll?statusType=${statusType}`, gridRequest, { headers: this.authService.getAuthenticationHeader() })
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

    public getCandidateByVacancy(vacancyId: number): Observable<any> {
        return this.http.get(`http://localhost:8000/candidate/getByVacancy?vacancyId=${vacancyId}`, { headers: this.authService.getAuthenticationHeader() })
    } 

    public candidateGetByTechnologyAndExperience(experience: number, technologyIds: number[]): Observable<any> {
        return this.http.post(`http://localhost:8000/candidate/getByTechnologyAndExperience?experience=${experience}`, technologyIds, { headers: this.authService.getAuthenticationHeader() })
    }

    public attachVacancyToCandidateStage(request: any): Observable<any> {
        return this.http.post(`http://localhost:8000/vacancy/attachCandidate`, request, { headers: this.authService.getAuthenticationHeader() });
    }

    public detachCandidate(fomrData: any): Observable<any> {
        return this.http.post(`http://localhost:8000/Vacancy/DetachCandidate`, fomrData, { headers: this.authService.getAuthenticationHeader() })
    }


}