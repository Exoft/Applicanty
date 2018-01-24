import { Component, Input, ViewContainerRef } from '@angular/core';
import { State } from 'clarity-angular';
import { VacanciesDataService } from '../../services/vacancies-data.service';
import { Router } from '@angular/router';
import { NotificationService } from "../../../../services/notification.service";
import { StatusCommands } from "../../../../constanta/statuscommands";
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
                that.notificationService.notify(NotificationType.Success, 'Data for vacacies datagrid loading successfully.');
            },
            error => {
                that.loading = false;
                that.notificationService.notify(NotificationType.Error, 'Data for vacacies datagrid don\'t loading.');
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
                    message + 'status not changed');
            });

        this.showModal = false;
    }
}