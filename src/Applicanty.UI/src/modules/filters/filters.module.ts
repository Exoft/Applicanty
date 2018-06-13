import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ClarityModule } from '@clr/angular';

import { ExperienceFilterComponent } from '../filters/experience-filter/experience-filter';
import { PriorityFilterComponent } from '../filters/priority-filter/priority-filter';
import { TextFilterComponent } from '../filters/text-filter/text-filter';
import { AgeFilterComponent } from './age-filter/age-filter';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';

@NgModule({
    declarations: [
        ExperienceFilterComponent,
        PriorityFilterComponent,
        TextFilterComponent,
        AgeFilterComponent
    ],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ClarityModule,
        RouterModule,
        TranslateModule
    ],
    exports: [
        ExperienceFilterComponent,
        PriorityFilterComponent,
        TextFilterComponent,
        AgeFilterComponent
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class FiltersModule { }
