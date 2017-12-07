import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { LoginComponent } from './components/login/login.component';
import { userPageComponent } from './components/userPage/userPage.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ClarityModule } from 'clarity-angular';

import { HttpClientModule } from '@angular/common/http';

@NgModule({
    declarations: [
        AppComponent,
        LoginComponent,
        userPageComponent,
    ],
    imports: [
        CommonModule,
        ClarityModule.forRoot(),
        BrowserAnimationsModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'login', pathMatch: 'full' },
            { path: 'login', component: LoginComponent },
            { path: '**', redirectTo: 'login' },
            { path: 'userPage', component: userPageComponent },
        ])
    ],
})
export class AppModuleShared {

}
