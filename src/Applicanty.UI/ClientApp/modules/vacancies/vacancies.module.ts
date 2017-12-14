import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Routes, RouterModule } from '@angular/router';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ClarityModule } from 'clarity-angular';

import { VacanciesComponent } from '../vacancies/components/vacancies.component';
import { AuthGuard } from '../../services/authguard.service';

import { HttpClientModule } from '@angular/common/http';

export const vacanciesRoutes = [
    { path: 'vacancies', component: VacanciesComponent, canActivate: [AuthGuard] }
];

@NgModule({
    declarations: [
        VacanciesComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class VacanciesModule {
}
