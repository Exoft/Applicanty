import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Routes, RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ClarityModule } from 'clarity-angular';

import { CandidatesListComponent } from '../candidates/components/candidates-list/candidates-list.component';
import { CandidatePageComponent } from '../candidates/components/candidate-page/candidate-page.component';
import { AuthGuard } from '../../services/authguard.service';

import { CandidatesDataService } from './services/candidates-data.service';

import { HttpClientModule } from '@angular/common/http';

export const candidateRoutes = [
    { path: 'candidates', component: CandidatesListComponent, canActivate: [AuthGuard] },
    { path: 'candidate/:candidateId', component: CandidatePageComponent, canActivate: [AuthGuard] }
];

@NgModule({
    declarations: [
        CandidatesListComponent,
        CandidatePageComponent
    ],
    providers: [
        CandidatesDataService
    ],
    imports: [
        BrowserModule,
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule,
        ReactiveFormsModule,
        ClarityModule.forRoot(),
        BrowserAnimationsModule,
        HttpClientModule
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class CandidatesModule {
}
