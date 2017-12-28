import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ClarityModule } from 'clarity-angular';
import { DashboardComponent } from '../dashboard/components/dashboard.component';
import { AuthGuard } from '../../services/authguard.service';

export const dashboardRoutes = [
    { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] }
];

@NgModule({
    declarations: [
        DashboardComponent
    ],
    imports: [
        BrowserModule,
        ClarityModule.forRoot()
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class DashboardModule {}
