import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ClarityModule } from '@clr/angular';

import { ExperienceFilter } from "../filters/experience-filter/experience-filter";
import { PriorityFilter } from "../filters/priority-filter/priority-filter";
import { TextFilter } from "../filters/text-filter/text-filter";
import { AgeFilter } from "./age-filter/age-filter";
import { RouterModule } from "@angular/router";
import { TranslateModule } from "@ngx-translate/core";

@NgModule({
    declarations: [
        ExperienceFilter,
        PriorityFilter,
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
        PriorityFilter,
        TextFilter,
        AgeFilter
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class FiltersModule { }
