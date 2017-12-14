import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { AuthService } from '../../../services/auth.service';

@Injectable()
export class CandidatesDataService {
    constructor(private http: HttpClient,
        private authService: AuthService) {
    }
    
    public getCandidates() {
        return this.http.get('http://localhost:8000/api/candidate', { headers: this.authService.getAuthenticationHeader() });
    }

    public getCandidate(candidateId: any) {
        return this.http.get('http://localhost:8000/api/candidate/' + candidateId, { headers: this.authService.getAuthenticationHeader() });
    }

    public createCandidate(candidate: any) {
        return this.http.post('http://localhost:8000/api/candidate', candidate, { headers: this.authService.getAuthenticationHeader() });
    }

    public updateCandidate(candidate: any) {
        return this.http.put('http://localhost:8000/api/candidate', candidate, { headers: this.authService.getAuthenticationHeader() });
    }

    public deleteCandidate(candidateId: any) {
        return this.http.delete('http://localhost:8000/api/candidate/' + candidateId, { headers: this.authService.getAuthenticationHeader() });
    }
}