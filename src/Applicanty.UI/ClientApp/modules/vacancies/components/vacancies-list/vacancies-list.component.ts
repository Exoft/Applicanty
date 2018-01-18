import { Component, Input } from '@angular/core';
import { State } from "clarity-angular";
import { VacanciesDataService } from "../../services/vacancies-data.service";

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

    constructor(private vacanciesDataService: VacanciesDataService) {
    }

    refresh(state: State) {
        this.loading = true;
        this.curentPage = state.page;
        this.vacanciesDataService.getVacancies(this.curentPage.from, this.curentPage.size).subscribe(
            data => {
                this.vacanciesList = data.result;
                this.totalCount = data.totalCount;
                this.loading = false;
                this.loadingError = false;
            },
            error => {
                this.loading = false;
                this.loadingError = true;
            }
        );
    }

    deleteVacancies() {
        if (this.selectedItems.length !== 0) {
            this.vacanciesDataService.deleteVacancies(this.selectedItems.map(arr => arr.id));
        }
        this.showModal = false;
    }
}