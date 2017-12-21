import { Component, Input, OnInit } from '@angular/core';
import { VacanciesDataService } from '../../services/vacancies-data.service';


@Component({
    templateUrl: './vacancies-list.component.html',
    styleUrls: ['./vacancies-list.component.scss'],
    providers: [VacanciesDataService]
})
export class VacanciesListComponent implements OnInit {
    @Input() salary: number = 150;
    private take: number = 10;
    private skip: number = 0;
    private totalCount: number = 0;

    public vacanciesList: any[];
    onScroll() {
        console.log('scrolled!!!');
        if (this.skip <= this.totalCount) {
            this.vacanciesDataService.getVacancies(this.take, this.skip).subscribe(data => {
                console.log(data);
                for (var item of data.result) {
                    this.vacanciesList.push(item);
                }
                this.totalCount = data.totalCount;
            });
            this.skip += this.take;
            console.log(this.vacanciesList);
        }
    }
    
    constructor(private vacanciesDataService: VacanciesDataService) {}
    ngOnInit() {
        this.vacanciesDataService.getVacancies(this.take, this.skip).subscribe(data => {
            this.vacanciesList = data.result;
            this.totalCount = data.totalCount;
        });

        this.skip += this.take;
    }
}