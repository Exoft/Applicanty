import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ClarityModule } from 'clarity-angular';

import { AuthModule, authRoutes } from '../auth/auth.module';

import { LoginComponent } from '../auth/components/login/login.component';

import { AuthService } from '../../services/auth.service';

import 'clarity-icons';

@NgModule({
    declarations: [
        AppComponent,
        LoginComponent
    ],
    providers: [AuthService],
    imports: [
        AuthModule,
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ClarityModule.forRoot(),
        BrowserAnimationsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'userpage', pathMatch: 'full' },

            ...authRoutes,

            { path: '**', redirectTo: 'userpage' }
        ])
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModuleShared {

}