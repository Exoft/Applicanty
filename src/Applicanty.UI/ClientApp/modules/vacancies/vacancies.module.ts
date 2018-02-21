﻿import { AppModuleShared } from '../app/app.shared.module';
import { TranslateModule } from '@ngx-translate/core';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Routes, RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ClarityModule } from 'clarity-angular';

import { FroalaEditorModule, FroalaViewModule } from 'angular-froala-wysiwyg';

import { VacanciesListComponent } from '../vacancies/components/vacancies-list/vacancies-list.component';
import { AuthGuard } from '../../services/authguard.service';
import { VacancyPageComponent } from '../vacancies/components/vacancy-page/vacancy-page.component';
import { ExperienceFilter } from "../filters/experience-filter/experience-filter";
import { DateFilter } from "../filters/date-filter/date-filter";
import { TextFilter } from "../filters/text-filter/text-filter";

import { VacanciesDataService } from './services/vacancies-data.service';
import { EnumDataService } from '../../services/enum.data.service';

import { HttpClientModule } from '@angular/common/http';

import '../../../node_modules/froala-editor/js/froala_editor.pkgd.min';

export const vacanciesRoutes = [
    { path: 'vacancies', component: VacanciesListComponent, canActivate: [AuthGuard] },
    { path: 'vacancies/details/:id', component: VacancyPageComponent, canActivate: [AuthGuard] },
    { path: 'vacancies/newvacancy', component: VacancyPageComponent, canActivate: [AuthGuard] },
];

@NgModule({
    declarations: [
        VacanciesListComponent,
        VacancyPageComponent,
        ExperienceFilter,
        DateFilter,
        TextFilter
    ],
    providers: [
        VacanciesDataService,
        EnumDataService
    ],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        CommonModule,
        HttpModule,
        FormsModule,
        ClarityModule.forRoot(),
        FroalaEditorModule.forRoot(), 
        FroalaViewModule.forRoot(),
        ReactiveFormsModule,
        RouterModule,
        HttpClientModule,
        TranslateModule
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class VacanciesModule {}
