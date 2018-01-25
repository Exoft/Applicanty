import { Component, Input, ViewContainerRef } from '@angular/core';
import { State } from 'clarity-angular';
import { VacanciesDataService } from '../../services/vacancies-data.service';
import { Router } from '@angular/router';
import { NotificationService } from "../../../../services/notification.service";
import { StatusCommands } from "../../../../constants/status-commands";
import { NotificationType } from "../../../../enums/notification-type";

@Component({
    templateUrl: './vacancies-list.component.html',
    styleUrls: ['./vacancies-list.component.scss'],
})
export class VacanciesListComponent {
    @Input() salary: number = 150;

    public selectedItems: any[] = [];

    public loading: boolean = true;
    public showModal: boolean = false;

    public vacanciesList: any[];

    public deleted = StatusCommands.DELETED;
    public archived = StatusCommands.ARCHIVED;
    public active = StatusCommands.ACTIVE;

    public totalCount: number = 0;
    private curentPage;

    constructor(private vacanciesDataService: VacanciesDataService,
        private notificationService: NotificationService) {
    }

    public refresh(state: State) {
        let that = this;
        that.loading = true;
        that.curentPage = state.page;
        that.vacanciesDataService.getVacancies(that.curentPage.from, that.curentPage.size).subscribe(
            data => {
                that.vacanciesList = data.result;
                that.totalCount = data.totalCount;
                that.loading = false;
            },
            error => {
                that.loading = false;
                that.notificationService.notify(NotificationType.Error, 'Error occurred during loading vacancy data');
            }
        );
    }

    public changeStatus($event, vacancies: any[], status) {
        let that = this;
        let message = vacancies.length === 1 ? 'Vacancy ' : 'Vacancies ';

        that.vacanciesDataService.changeVacanciesStatus(vacancies.map(arr => arr.id), status).subscribe(data => {
            if (data) {
                that.notificationService.notify(NotificationType.Success,
                    message + 'status changed successfully');
            }
        },
            error => {
                that.notificationService.notify(NotificationType.Error,
                    'Error occurred during status change');
            });

        this.showModal = false;
    }
}