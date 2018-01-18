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

import { VacanciesDataService } from './services/vacancies-data.service';

import { HttpClientModule } from '@angular/common/http';

import '../../../node_modules/froala-editor/js/froala_editor.pkgd.min';

export const vacanciesRoutes = [
    { path: 'vacancies', component: VacanciesListComponent, canActivate: [AuthGuard] },
    { path: 'vacancy/:id', component: VacancyPageComponent, canActivate: [AuthGuard] }
];

@NgModule({
    declarations: [
        VacanciesListComponent,
        VacancyPageComponent
    ],
    providers: [
        VacanciesDataService
    ],
    imports: [
        BrowserModule,
        CommonModule,
        HttpModule,
        FormsModule,
        ClarityModule.forRoot(),
        FroalaEditorModule.forRoot(), 
        FroalaViewModule.forRoot(),
        ReactiveFormsModule,
        RouterModule,
        HttpClientModule
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class VacanciesModule {}
