import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Routes, RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';

import { AppComponent } from './components/app/app.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ClarityModule } from 'clarity-angular';

import { AuthModule, authRoutes } from '../auth/auth.module';
import { VacanciesModule, vacanciesRoutes } from '../vacancies/vacancies.module';
import { CandidatesModule, candidateRoutes } from '../candidates/candidates.module';
import { DashboardModule, dashboardRoutes } from '../dashboard/dashboard.module';
import { NotFoundModule, notfoundRoutes } from "../notfound/notfound.module";
import { FiltersModule } from "../filters/filters.module";
import { SettingsModule, settingsRoutes } from "../settings/settings.module"

import { NotificationComponent } from '../auth/components/notification/notification.component';

import { AuthService } from '../../services/auth.service';
import { AuthGuard } from '../../services/authguard.service';
import { NotificationService } from '../../services/notification.service';

import 'clarity-icons';
import 'clarity-icons/shapes/all-shapes';
import { HTTP_INTERCEPTORS } from "@angular/common/http";
import { AuthenticationInterceptor } from "../../services/http-interceptor";

@NgModule({
    declarations: [
        AppComponent,
        NotificationComponent
    ],
    providers: [
        AuthService,
        NotificationService,
        AuthGuard,
        { provide: HTTP_INTERCEPTORS, useClass: AuthenticationInterceptor, multi: true }
    ],
    imports: [
        AuthModule,
        VacanciesModule,
        CandidatesModule,
        DashboardModule,
        NotFoundModule,
        FiltersModule,
        SettingsModule,
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        ClarityModule.forRoot(),
        BrowserAnimationsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'dashboard', pathMatch: 'full' },

            ...authRoutes,

            ...vacanciesRoutes,

            ...candidateRoutes,

            ...dashboardRoutes,

            ...notfoundRoutes,

            ...settingsRoutes,
            
            { path: '**', redirectTo: 'notfound' }
        ]),
        TranslateModule.forRoot()
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModuleShared {

}
