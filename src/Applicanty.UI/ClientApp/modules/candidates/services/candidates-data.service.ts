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
    
    public getCandidates(skip: number = 0, take: number = 10): Observable<any> {
        return this.http.get(`http://localhost:8000/candidate?skip=${skip}&take=${take}`, { headers: this.authService.getAuthenticationHeader() });
    }

    public getCandidate(candidateId: any): Observable<any> {
        return this.http.get('http://localhost:8000/candidate/' + candidateId, { headers: this.authService.getAuthenticationHeader() });
    }

    public createCandidate(candidate: any): Observable<any> {
        return this.http.post('http://localhost:8000/candidate', candidate, { headers: this.authService.getAuthenticationHeader() });
    }

    public updateCandidate(candidate : any): Observable<any> {
        return this.http.put('http://localhost:8000/candidate', candidate, { headers: this.authService.getAuthenticationHeader() });
    }

    public deleteCandidate(candidateId: any): Observable<any> {
        return this.http.delete('http://localhost:8000/candidate/' + candidateId, { headers: this.authService.getAuthenticationHeader() });
    }
}