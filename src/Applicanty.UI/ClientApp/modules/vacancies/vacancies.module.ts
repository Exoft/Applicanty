import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Routes, RouterModule } from '@angular/router';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { BrowserModule } from '@angular/platform-browser';

import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ClarityModule } from 'clarity-angular';

import { VacanciesListComponent } from '../vacancies/components/vacancies-list/vacancies-list.component';
import { AuthGuard } from '../../services/authguard.service';
import { VacancyComponent } from '../vacancies/components/vacancy/vacancy.component';
import { VacancyPageComponent } from '../vacancies/components/vacancy-page/vacancy-page.component';

import { VacanciesDataService } from './services/vacancies-data.service';

import { HttpClientModule } from '@angular/common/http';

export const vacanciesRoutes = [
    { path: 'vacancies', component: VacanciesListComponent, canActivate: [AuthGuard] },
    { path: 'vacancy/:vacancyId', component: VacancyPageComponent, canActivate: [AuthGuard] }
];

@NgModule({
    declarations: [
        VacanciesListComponent,
        VacancyComponent,
        VacancyPageComponent
    ],
    providers: [
        VacanciesDataService
    ],
    imports: [
        BrowserModule,
        InfiniteScrollModule,
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule,
        HttpClientModule
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class VacanciesModule {}
