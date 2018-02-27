import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import { AuthService } from '../../../services/auth.service';
import { GridRequest } from "../../../services/grid-request";

@Injectable()
export class CandidatesDataService {
    constructor(private http: HttpClient,
        private authService: AuthService) {
    }

    public getCandidates(statusType: number, gridRequest: GridRequest): Observable<any> {
        return this.http.post(`http://localhost:8000/candidate/getAll?statusType=${statusType}`, gridRequest, { headers: this.authService.getAuthenticationHeader() });
    }

    public getCandidate(candidateId: any): Observable<any> {
        return this.http.get('http://localhost:8000/candidate/' + candidateId, { headers: this.authService.getAuthenticationHeader() });
    }

    public createCandidate(candidate: any): Observable<any> {
        return this.http.post('http://localhost:8000/candidate', candidate, { headers: this.authService.getAuthenticationHeader() });
    }

    public updateCandidate(candidate: any): Observable<any> {
        return this.http.put('http://localhost:8000/candidate', candidate, { headers: this.authService.getAuthenticationHeader() });
    }

    public deleteCandidate(candidateId: any): Observable<any> {
        return this.http.delete('http://localhost:8000/candidate/' + candidateId, { headers: this.authService.getAuthenticationHeader() });
    }

    public changeCandidateStatus(ids: number[], status: any): Observable<any> {
        return this.http.post('http://localhost:8000/candidate/changeStatus?status=' + status, ids, { headers: this.authService.getAuthenticationHeader() });
    }

    public getTechnologies(): Observable<any> {
        return this.http.get('http://localhost:8000/technology', { headers: this.authService.getAuthenticationHeader() });
    }

    public getExperiences(): Observable<any> {
        return this.http.get('http://localhost:8000/enum/Experience');
    }

    public getCandidateByVacancyStage(vacancyId: number, stageId: number): Observable<any> {
        return this.http.get(`http://localhost:8000/candidate/getByVacancyAndStage?vacancyId=${vacancyId}&stageId=${stageId}`, { headers: this.authService.getAuthenticationHeader() });
    }

    public attachCandidateStageToVacancy(formData: number): Observable<any> {
        return this.http.post(`http://localhost:8000/vacancy/attachCandidate`, formData, { headers: this.authService.getAuthenticationHeader() });
    }
   
    public getByCandidate(candidateId: number): Observable<any> {
        return this.http.get(`http://localhost:8000/vacancy/getByCandidate?candidateId=${candidateId}`, { headers: this.authService.getAuthenticationHeader() });
    }

    public getVacancyByTechnologyAndExperience(experienceId: number, selectedTechnologies): Observable<any> {
        return this.http.post(`http://localhost:8000/vacancy/getByTechnologyAndExperience?experience=${experienceId}`, selectedTechnologies , { headers: this.authService.getAuthenticationHeader() });
    }

    public detachVacancy(formData: any): Observable<any> {
        return this.http.post(`http://localhost:8000/vacancy/detachCandidate`, formData, { headers: this.authService.getAuthenticationHeader() }) 
    }
}