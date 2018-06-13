import { TranslateModule } from '@ngx-translate/core';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Routes, RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ClarityModule } from '@clr/angular';
import { AuthGuard } from '../../services/authguard.service';

import { SettingsPageComponent } from './components/settings-page.component';
import { SettingsDataService } from './services/settings-data.services';


export const settingsRoutes = [
    { path: 'settings', component: SettingsPageComponent, canActivate: [AuthGuard] }
];

@NgModule({
    declarations: [
        SettingsPageComponent
    ],
    providers: [
        SettingsDataService
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
        TranslateModule

    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class SettingsModule {
}