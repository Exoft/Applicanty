import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Routes, RouterModule } from '@angular/router';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ClarityModule } from 'clarity-angular';

import { SignInComponent } from './components/sign-in/sign-in.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { UserProfilePageComponent } from './components/user-profile-page/user-profile-page.component';
import { EmailVerificationComponent } from './components/email-verification/email-verification.component';

import { AuthGuard } from '../../services/authguard.service';
import { ValidationService } from '../../services/validation.service';

import { HttpClientModule } from '@angular/common/http';

export const authRoutes = [
    { path: 'profile', component: UserProfilePageComponent, canActivate: [AuthGuard]},
    { path: 'signin', component: SignInComponent },
    { path: 'signup', component: SignUpComponent },
    { path: 'emailverification', component: EmailVerificationComponent }
];

@NgModule({
    providers: [
        ValidationService
    ],
    declarations: [
        UserProfilePageComponent,
        SignInComponent,
        SignUpComponent,
        EmailVerificationComponent
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
