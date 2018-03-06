import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ClarityModule } from 'clarity-angular';

import { ExperienceFilter } from "../filters/experience-filter/experience-filter";
import { DateFilter } from "../filters/date-filter/date-filter";
import { TextFilter } from "../filters/text-filter/text-filter";
import { AgeFilter } from "./age-filter/age-filter";
import { RouterModule } from "@angular/router";
import { TranslateModule } from "@ngx-translate/core";

@NgModule({
    declarations: [
        ExperienceFilter,
        DateFilter,
        TextFilter,
        AgeFilter
    ],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ClarityModule.forRoot(),
        RouterModule,
        TranslateModule
    ],
    exports: [
        ExperienceFilter,
        DateFilter,
        TextFilter,
        AgeFilter
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class FiltersModule { }
