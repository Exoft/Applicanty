import { Component, ViewChild, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';
import { ClarityIcons } from '@clr/icons';

import * as $ from 'jquery';

import { AuthService } from '../../../../services/auth.service';
import { NotificationService } from '../../../../services/notification.service';

import { NotificationComponent } from '../../../auth/components/notification/notification.component';

import { translations as enTranslations } from './../../../../i18n/en';
import { translations as uaTranslations } from './../../../../i18n/ua';

import { environment } from '../../../../environments/environment';

@Component({
    selector: 'apl-app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
    @ViewChild(NotificationComponent) set notificationComponent(notificationComponent: NotificationComponent) {
        if (notificationComponent) {
            this.notificationService.initialize(notificationComponent);
        }
    }

    public uiModulesVersion = '';
    public apiVersion = '';

    constructor(public authService: AuthService,
        private notificationService: NotificationService,
        private translateService: TranslateService,
        private http: HttpClient) {

        translateService.addLangs(['en', 'ua']);

        translateService.setTranslation('en', enTranslations);
        translateService.setTranslation('ua', uaTranslations);

        translateService.setDefaultLang('en');

        translateService.use('en');
    }

    ngOnInit() {
        this.uiModulesVersion = environment.version;

        this.http.get<{ version: string }>(`${environment.apiRootUrl}version`)
            .subscribe(result => {
                this.apiVersion = result.version;
            });
    }

    public logoutClick(e) {
        e.preventDefault();

        this.authService.signOut();
    }

    public changeLanguageClick(lang: string) {
        this.translateService.use(lang);
    }
}
