import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Routes, RouterModule } from '@angular/router';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ClarityModule } from 'clarity-angular';

import { VacanciesListComponent } from '../vacancies/components/vacancies-list/vacancies-list.component';
import { AuthGuard } from '../../services/authguard.service';
import { VacancyComponent } from '../vacancies/components/vacancy/vacancy.component';

import { VacanciesDataService } from './services/vacancies-data.service';

import { HttpClientModule } from '@angular/common/http';

export const vacanciesRoutes = [
    { path: 'vacancies', component: VacanciesListComponent, canActivate: [AuthGuard] }
];

@NgModule({
    declarations: [
        VacanciesListComponent,
        VacancyComponent
        //here will be vacancy component and vacancy's page
    ],
    providers: [
        VacanciesDataService
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
