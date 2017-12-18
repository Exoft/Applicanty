import { Component, Input, OnInit } from '@angular/core';
import { VacanciesDataService } from '../../services/vacancies-data.service';

@Component({
    templateUrl: './vacancies-list.component.html',
    styleUrls: ['./vacancies-list.component.scss'],
    providers: [VacanciesDataService]
})
export class VacanciesListComponent implements OnInit {
    @Input() salary: number = 150;

    vacanciesList = [];

    constructor(private vacanciesDataService: VacanciesDataService) { }
    ngOnInit() {
        this.vacanciesDataService.getVacancies().subscribe(data => this.vacanciesList = data);
            //.subscribe(data => console.log(data));
    }
}