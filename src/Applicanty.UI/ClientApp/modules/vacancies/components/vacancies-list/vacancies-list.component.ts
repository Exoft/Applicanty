import { Component, Input } from '@angular/core';
import { State } from "clarity-angular";
import { VacanciesDataService } from "../../services/vacancies-data.service";

@Component({
    templateUrl: './vacancies-list.component.html',
    styleUrls: ['./vacancies-list.component.scss'],
})
export class VacanciesListComponent {
    @Input() salary: number = 150;

    @Input() selectedItem: any[] = [];

    private curentPage;
    public totalCount: number = 0;
    public loading: boolean = true;
    public loadingError: boolean = false;

    public deleteButtonclick: boolean = false;
    public modalsMessage: string;
    private deleting: number[]=[];

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

    showModal() {
        this.deleteButtonclick = true;
        if (this.selectedItem.length == 0) {
            this.modalsMessage="You don't selected item for deleting. Try again";
        }
        else {
            this.modalsMessage="You realy want to delete selected items?"
        }
    }
    delete() {
        if (this.selectedItem.length !== 0) {
            for (let item of this.selectedItem) {
                this.deleting.push(item.id);
            }
            this.vacanciesDataService.deleteVacancy(this.deleting);
        }
        this.deleteButtonclick = false;
    }
}