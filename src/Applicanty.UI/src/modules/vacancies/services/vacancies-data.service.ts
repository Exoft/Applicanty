import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';

import { AuthService } from '../../../services/auth.service';
import { GridRequest } from "../../../services/grid-request";
import { environment } from '../../../environments/environment';

@Injectable()
export class VacanciesDataService {
    constructor(private http: HttpClient,
        private authService: AuthService) {
    }

    public getVacancies(statusType: number, gridRequest: GridRequest): Observable<any> {
        let params = new HttpParams();

        params = params.set('statusType', statusType.toString());

        return this.http.post(`${environment.apiRootUrl}vacancy/getAll`, gridRequest, { headers: this.authService.getAuthenticationHeader(), params: params })
    }

    public getVacancy(vacancyId: any): Observable<any> {
        return this.http.get(`${environment.apiRootUrl}vacancy/${vacancyId}`, { headers: this.authService.getAuthenticationHeader() });
    }

    public createVacancy(vacancy: any): Observable<any> {
        return this.http.post('${environment.apiRootUrl}vacancy', vacancy, { headers: this.authService.getAuthenticationHeader() });
    }

    public updateVacancy(vacancy: any): Observable<any> {
        return this.http.put('${environment.apiRootUrl}vacancy', vacancy, { headers: this.authService.getAuthenticationHeader() });
    }

    public changeVacanciesStatus(ids: number[], status: any): Observable<any> {
        let params = new HttpParams();

        params = params.set('status', status.toString());

        return this.http.post(`${environment.apiRootUrl}vacancy/changeStatus`, ids, { headers: this.authService.getAuthenticationHeader(), params: params });
    }

    public getTechnologies(): Observable<any> {
        return this.http.get(`${environment.apiRootUrl}technology`, { headers: this.authService.getAuthenticationHeader() });
    }

    public getVacancyStagesCount(id: number): Observable<any> {
        let params = new HttpParams();

        params = params.set('id', id.toString());

        return this.http.get(`${environment.apiRootUrl}vacancy/countVacancyStageCandidates`, { headers: this.authService.getAuthenticationHeader(), params: params })
    }

    public getCandidateByVacancy(vacancyId: number): Observable<any> {
        let params = new HttpParams();

        params = params.set('vacancyId', vacancyId.toString());

        return this.http.get(`${environment.apiRootUrl}candidate/getByVacancy`, { headers: this.authService.getAuthenticationHeader(), params: params })
    } 

    public getCandidateByTechnologyAndExperience(experience: number, technologyIds: number[]): Observable<any> {
        let params = new HttpParams();

        params = params.set('experience', experience.toString());

        return this.http.post(`${environment.apiRootUrl}candidate/getByTechnologyAndExperience`, technologyIds, { headers: this.authService.getAuthenticationHeader(), params: params })
    }

    public attachVacancyToCandidateStage(request: any): Observable<any> {
        return this.http.post(`${environment.apiRootUrl}vacancy/attachCandidate`, request, { headers: this.authService.getAuthenticationHeader() });
    }

    public detachCandidate(formData: any): Observable<any> {
        return this.http.post(`${environment.apiRootUrl}Vacancy/DetachCandidate`, formData, { headers: this.authService.getAuthenticationHeader() })
    }


}