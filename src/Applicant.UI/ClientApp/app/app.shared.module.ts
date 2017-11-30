import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { LoginComponent } from './components/login/login.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ClarityModule } from 'clarity-angular';

@NgModule({
    declarations: [
        AppComponent,
        LoginComponent
    ],
    imports: [
        CommonModule,
        ClarityModule.forRoot(),
        BrowserAnimationsModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'login', pathMatch: 'full' },
            { path: 'login', component: LoginComponent },
            { path: '**', redirectTo: 'login' }
        ])
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModuleShared {
}
