import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import { AuthService } from '../../../services/auth.service';

@Injectable()
export class CandidatesDataService {
    constructor(private http: HttpClient,
        private authService: AuthService) {
    }

    public getCandidates(skip: number = 0, take: number = 10,
        sortBy: string, sortDir: string, statusType: number): Observable<any> {
        return this.http.get(`http://localhost:8000/candidate?skip=${skip}&take=${take}&sortField=${sortBy}&sortDir=${sortDir}&statusType=${statusType}`, { headers: this.authService.getAuthenticationHeader() });
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
        return this.http.post('http://localhost:8000/Candidate/ChangeStatus?status=' + status, ids, { headers: this.authService.getAuthenticationHeader() });
    }

    public getTechnologies(): Observable<any> {
        return this.http.get('http://localhost:8000/technology', { headers: this.authService.getAuthenticationHeader() });
    }

    public getExperiences(): Observable<any> {
        return this.http.get('http://localhost:8000/enum/Experience');
    }

    public getCandidateByVacancyStage(vacancyId: number, stageId: number): Observable<any> {
        return this.http.get(`http://localhost:8000/candidate/getByVacancy?vacancyId=${vacancyId}&stageId=${stageId}`, { headers: this.authService.getAuthenticationHeader() })
    }

    public changeCandidateStage(): Observable<any> {
        return this.http.post(`http://localhost:8000/Vacancy/AttachCandidate`, { headers: this.authService.getAuthenticationHeader() })
    }
}