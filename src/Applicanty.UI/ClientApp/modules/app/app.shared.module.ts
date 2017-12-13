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
import { CandidateModule, candidateRoutes } from '../candidate/candidate.module';

import { AuthService } from '../../services/auth.service';
import { AuthGuard } from '../../services/authguard.service';

import 'clarity-icons';

@NgModule({
    declarations: [
        AppComponent
    ],
    providers: [
        AuthService,
        AuthGuard
    ],
    imports: [
        AuthModule,
        VacanciesModule,
        CandidateModule,
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ClarityModule.forRoot(),
        BrowserAnimationsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'vacancies', pathMatch: 'full' },

            ...authRoutes,

            ...vacanciesRoutes,

            ...candidateRoutes,
            
            { path: '**', redirectTo: 'notfound' }
        ])
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModuleShared {

}
