import { Component, Input } from '@angular/core';
import { State } from 'clarity-angular';
import { VacanciesDataService } from '../../services/vacancies-data.service';
import { Router } from '@angular/router';

@Component({
    templateUrl: './vacancies-list.component.html',
    styleUrls: ['./vacancies-list.component.scss'],
})
export class VacanciesListComponent {
    @Input() salary: number = 150;

    public selectedItems: any[] = [];

    private curentPage;
    public totalCount: number = 0;
    public loading: boolean = true;
    public loadingError: boolean = false;

    public showModal: boolean = false;

    public vacanciesList: any[];

    constructor(private vacanciesDataService: VacanciesDataService,
        private router: Router) {
    }

    refresh(state: State) {
        let that = this;
        that.loading = true;
        that.curentPage = state.page;
        that.vacanciesDataService.getVacancies(that.curentPage.from, that.curentPage.size).subscribe(
            data => {
                that.vacanciesList = data.result;
                that.totalCount = data.totalCount;
                that.loading = false;
                that.loadingError = false;
            },
            error => {
                that.loading = false;
                that.loadingError = true;
            }
        );
    }

    deleteVacancies(event) {
        if (this.selectedItems.length !== 0) {
            this.vacanciesDataService.deleteVacancies(this.selectedItems.map(arr => arr.id)).subscribe();
        }
        this.showModal = false;
    }
}