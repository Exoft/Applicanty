import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ClarityModule } from 'clarity-angular';

import { AuthModule, authRoutes } from '../auth/auth.module';
import { VacanciesModule, vacanciesRoutes } from '../vacancies/vacancies.module';
import { CandidatesModule, candidateRoutes } from '../candidates/candidates.module';
import { DashboardModule, dashboardRoutes } from '../dashboard/dashboard.module';

import { NotificationComponent } from '../auth/components/notification/notification.component';

import { AuthService } from '../../services/auth.service';
import { AuthGuard } from '../../services/authguard.service';
import { NotificationService } from '../../services/notification.service';

import 'clarity-icons';
import 'clarity-icons/shapes/all-shapes';

@NgModule({
    declarations: [
        AppComponent,
        NotificationComponent
    ],
    providers: [
        AuthService,
        NotificationService,
        AuthGuard
    ],
    imports: [
        AuthModule,
        VacanciesModule,
        CandidatesModule,
        DashboardModule,
        CommonModule,
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
            
            { path: '**', redirectTo: 'notfound' }
        ])
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModuleShared {

}
