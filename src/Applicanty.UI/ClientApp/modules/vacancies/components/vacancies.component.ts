import { Component,Input } from '@angular/core';

@Component({
    selector: 'vacancies',
    templateUrl: './vacancies.component.html',
    styleUrls: ['./vacancies.component.scss']
})
export class VacanciesComponent {
    @Input() salary: number = 150;
}