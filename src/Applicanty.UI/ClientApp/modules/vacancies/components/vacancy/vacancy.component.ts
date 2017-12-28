import { Component, Input } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

@Component({
    selector: 'vacancy',
    templateUrl: './vacancy.component.html',
    styleUrls: ['./vacancy.component.scss']
})
export class VacancyComponent {
    @Input() vacancy: any;
}