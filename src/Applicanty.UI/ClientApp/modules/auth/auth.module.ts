import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Routes, RouterModule } from '@angular/router';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ClarityModule } from 'clarity-angular';

import { UserPageComponent } from './components/user-page/user-page.component';

import { HttpClientModule } from '@angular/common/http';

export const authRoutes = [
    { path: 'userpage', component: UserPageComponent }
];

@NgModule({
    declarations: [
        UserPageComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule
    ]
})
export class AuthModule {
}
