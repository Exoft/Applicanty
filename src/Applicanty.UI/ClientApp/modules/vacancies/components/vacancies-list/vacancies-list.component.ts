import { Component, Input } from '@angular/core';

@Component({
    templateUrl: './vacancies-list.component.html',
    styleUrls: ['./vacancies-list.component.scss']
})
export class VacanciesListComponent {
    @Input() salary: number = 150;
}