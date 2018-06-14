import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

import { AuthService } from '../../../services/auth.service';
import { environment } from '../../../environments/environment';

@Injectable()
export class SettingsDataService {
    constructor(private http: HttpClient,
        private authService: AuthService) {
    }

    public getTechnologies(): Observable<any> {
        return this.http.get('${environment.apiRootUrl}technology', { headers: this.authService.getAuthenticationHeader() });
    }

    public createNewTechnology(formData: any): Observable<any> {
        return this.http.post('${environment.apiRootUrl}Technology', formData, { headers: this.authService.getAuthenticationHeader() });
    }

    public deleteTechnology(id: number): Observable<any> {
        let params = new HttpParams();

        params = params.set('id', id.toString());

        return this.http.delete(`${environment.apiRootUrl}Technology`,
        { headers: this.authService.getAuthenticationHeader(), params: params });
    }
}
