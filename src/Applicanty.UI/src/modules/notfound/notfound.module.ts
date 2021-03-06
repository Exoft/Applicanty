﻿import { TranslateModule } from '@ngx-translate/core';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ClarityModule } from '@clr/angular';
import { NotFoundComponent } from '../notfound/components/notfound.component';
import { AuthGuard } from '../../services/authguard.service';
import { RouterModule } from '@angular/router';

export const notfoundRoutes = [
    { path: 'notfound', component: NotFoundComponent, canActivate: [AuthGuard] }
];

@NgModule({
    declarations: [
        NotFoundComponent
    ],
    imports: [
        BrowserModule,
        ClarityModule,
        RouterModule,
        TranslateModule
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class NotFoundModule {}
