import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Routes, RouterModule } from '@angular/router';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ClarityModule } from 'clarity-angular';

import { CandidateComponent } from '../candidate/components/candidate.component';
import { AuthGuard } from '../../services/authguard.service';

import { HttpClientModule } from '@angular/common/http';

export const candidateRoutes = [
    { path: 'candidate', component: CandidateComponent, canActivate: [AuthGuard] }
];

@NgModule({
    declarations: [
        CandidateComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule
    ]
})
export class CandidateModule {
}
