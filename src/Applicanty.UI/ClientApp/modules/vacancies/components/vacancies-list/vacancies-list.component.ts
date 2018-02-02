import { Component, Input, OnInit } from '@angular/core';
import { State } from 'clarity-angular';
import { VacanciesDataService } from '../../services/vacancies-data.service';
import { Router } from '@angular/router';
import { NotificationService } from "../../../../services/notification.service";
import { StatusCommands } from "../../../../constants/status-commands";
import { EnumNames } from "../../../../constants/enum-names";
import { NotificationType } from "../../../../enums/notification-type";
import { Comparator } from "clarity-angular";
import { EnumDataService } from "../../../../services/enum.data.service";
import { NotificationMassage } from "../../../../constants/notification-message";

@Component({
    templateUrl: './vacancies-list.component.html',
    styleUrls: ['./vacancies-list.component.scss'],
})
export class VacanciesListComponent implements OnInit {
    @Input() salary: number = 150;

    public selectedItems: any[] = [];

    public loading: boolean = true;

    public vacanciesList: any[];

    public deleted = StatusCommands.DELETED;
    public archived = StatusCommands.ARCHIVED;
    public active = StatusCommands.ACTIVE;

    public totalCount: number = 0;
    private currentPage;
    private sortField: { by: string | Comparator<any>, reverse: boolean } = { by: 'title', reverse: false };
    private currentState;

    private experiences: { [value: number]: any } = {};
    private statuses: { [value: number]: any } = {};

    constructor(private vacanciesDataService: VacanciesDataService,
        private notificationService: NotificationService,
        private enumService: EnumDataService) {
    }

    ngOnInit() {
        let that = this;

        that.enumService.getEnums(EnumNames.EXPERIENCE).subscribe(
            data => {
                if (data) {
                    for (let experience of data.result) {
                        let { value, name } = <{ value: number, name: string }>experience;
                        that.experiences[value] = name;
                    }
                }
            }, error => {
                that.notificationService.notify(NotificationType.Error, NotificationMassage.EXPERIENCELOADERROR);
            });

        that.enumService.getEnums(EnumNames.STATUSTYPE).subscribe(
            data => {
                if (data) {
                    for (let status of data.result) {
                        let { value, name } = <{ value: number, name: string }>status;
                        that.statuses[value] = name;
                    }
                }
            }, error => {
                that.notificationService.notify(NotificationType.Error, NotificationMassage.STATUSLOADERROR);
            });
    }

    public refresh(state: State) {
        let that = this;
        that.currentState = state;
        that.loading = true;
        that.currentPage = that.currentState.page;
        if (state.sort) {
            that.sortField = that.currentState.sort;
        }

        that.vacanciesDataService.getVacancies(that.currentPage.from, that.currentPage.size,
            that.sortField.by.toString(), that.sortField.reverse == true ? 'desc' : 'asc').subscribe(
            data => {
                that.vacanciesList = data.result;
                that.totalCount = data.totalCount;
                that.loading = false;
            },
            error => {
                that.loading = false;
                that.notificationService.notify(NotificationType.Error, NotificationMassage.VACANCIESLISTLOADERROR);
            });
        that.selectedItems = [];
    }

    public changeStatus($event, vacancies: any[], status) {
        let that = this;

        that.vacanciesDataService.changeVacanciesStatus(vacancies.map(arr => arr.id), status).subscribe(
            data => {
                if (data) {
                    that.notificationService.notify(NotificationType.Success,
                        vacancies.length === 1 ? NotificationMassage.VACANCYCHANGESTATUSSUCCES : NotificationMassage.VACANCIESCHANGESTATUSSUCCES);
                    that.refresh(that.currentState);
                }
            },
            error => {
                that.notificationService.notify(NotificationType.Error,
                    NotificationMassage.VACANCYCHANGESTATUSERROR);
            });

    }
}