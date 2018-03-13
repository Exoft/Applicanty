import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import { AuthService } from '../../../services/auth.service';

@Injectable()
export class SettingsDataService {
    constructor(private http: HttpClient,
        private authService: AuthService) {
    }

    public getTechnologies(): Observable<any> {
        return this.http.get('http://localhost:8000/technology', { headers: this.authService.getAuthenticationHeader() });
    }

    public createNewTechnology(formData: any): Observable<any> {
        return this.http.post('http://localhost:8000/Technology', formData, { headers: this.authService.getAuthenticationHeader() })
    }

    public deleteTechnology(id: number): Observable<any> {
        return this.http.delete(`http://localhost:8000/Technology?id=${id}`, { headers: this.authService.getAuthenticationHeader() })
    }

}