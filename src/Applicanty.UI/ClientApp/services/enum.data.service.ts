import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import { AuthService } from '../services/auth.service';

@Injectable()
export class EnumDataService {
    constructor(private http: HttpClient,
        private authService: AuthService) {
    }

    public getEnums(enumName: string): Observable<any> {
        return this.http.get(`http://localhost:8000/enum/${enumName}`, { headers: this.authService.getAuthenticationHeader() });
    }
}