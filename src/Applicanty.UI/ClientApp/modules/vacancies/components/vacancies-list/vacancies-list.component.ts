import { Component, Input,  OnInit } from '@angular/core';
import { State } from 'clarity-angular';
import { VacanciesDataService } from '../../services/vacancies-data.service';
import { Router } from '@angular/router';
import { NotificationService } from "../../../../services/notification.service";
import { StatusCommands } from "../../../../constants/status-commands";
import { EnumNames } from "../../../../constants/enum-names";
import { NotificationType } from "../../../../enums/notification-type";
import { Comparator } from "clarity-angular";
import { EnumDataService } from "../../../../services/enum.data.service";

@Component({
    templateUrl: './vacancies-list.component.html',
    styleUrls: ['./vacancies-list.component.scss'],
})
export class VacanciesListComponent implements OnInit {
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
    private sortField: { by: string | Comparator<any>, reverse: boolean } = { by: 'title', reverse: false };

    private experiences: { [value: number]: any } = {};
    private statuses: { [value: number]: any } = {};

    constructor(private vacanciesDataService: VacanciesDataService,
        private notificationService: NotificationService,
        private enumService: EnumDataService) {
    }

    ngOnInit() {
        let that = this;

        that.enumService.getEnums(EnumNames.EXPERIENCE).subscribe(data => {
            if (data) {
                for (let experience of data.result) {
                    let { value, name } = <{ value: number, name: string }>experience;
                    that.experiences[value] = name;
                }
            }
        }, error => {
            that.notificationService.notify(NotificationType.Error, 'Experience list not loaded.');
            });

        that.enumService.getEnums(EnumNames.STATUSTYPE).subscribe(data => {
            if (data) {
                for (let status of data.result) {
                    let { value, name } = <{ value: number, name: string }>status;
                    that.statuses[value] = name;
                }
            }
        }, error => {
            that.notificationService.notify(NotificationType.Error, 'Status list not loaded.');
        });
    }

    public refresh(state: State) {
        let that = this;
        that.loading = true;
        that.curentPage = state.page;
        if (state.sort) {
            that.sortField = state.sort;
        }

        that.vacanciesDataService.getVacancies(that.curentPage.from, that.curentPage.size,
            that.sortField.by.toString(), that.sortField.reverse == true ? 'desc' : 'asc').subscribe(
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