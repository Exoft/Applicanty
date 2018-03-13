import { Component, ViewChild } from '@angular/core';
import { ClarityIcons } from '@clr/icons';
import { TranslateService } from '@ngx-translate/core';

import * as $ from 'jquery';

import { AuthService } from '../../../../services/auth.service';
import { NotificationService } from "../../../../services/notification.service";

import { NotificationComponent } from "../../../auth/components/notification/notification.component";

import { translations as enTranslations } from './../../../../i18n/en';
import { translations as uaTranslations } from './../../../../i18n/ua';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent {
    @ViewChild(NotificationComponent) set notificationComponent(notificationComponent: NotificationComponent) {
        if (notificationComponent) {
            this.notificationService.initialize(notificationComponent);
        }
    }

    constructor(public authService: AuthService,
        private notificationService: NotificationService,
        private translateService: TranslateService) {

        translateService.addLangs(['en', 'ua']);

        translateService.setTranslation('en', enTranslations);
        translateService.setTranslation('ua', uaTranslations);

        translateService.setDefaultLang('en');

        translateService.use('en');
    }
    
    public logoutClick(e) {
        e.preventDefault();

        this.authService.signOut();
    }

    public changeLanguageClick(lang: string) {
        this.translateService.use(lang)
    }
}
