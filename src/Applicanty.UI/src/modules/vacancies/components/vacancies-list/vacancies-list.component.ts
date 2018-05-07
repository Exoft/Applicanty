﻿import { Component, Input, OnInit, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';

import { State, Comparator, Filter } from '@clr/angular';

import { VacanciesDataService } from '../../services/vacancies-data.service';
import { NotificationService } from "../../../../services/notification.service";
import { StatusCommands } from "../../../../constants/status-commands";
import { EnumNames } from "../../../../constants/enum-names";
import { NotificationType } from "../../../../enums/notification-type";
import { EnumDataService } from "../../../../services/enum.data.service";
import { GridFilterItem } from "../../../filters/grid-filter-item";
import { GridRequest } from "../../../../services/grid-request";
import { FilterOperators } from "../../../../constants/filter-opertors";

@Component({
    templateUrl: './vacancies-list.component.html',
    styleUrls: ['./vacancies-list.component.scss'],
})
export class VacanciesListComponent implements OnInit {
    public selectedItems: any[] = [];

    public loading: boolean = true;

    public vacanciesList: any[] = [];

    public deleted = StatusCommands.DELETED;
    public archived = StatusCommands.ARCHIVED;
    public active = StatusCommands.ACTIVE;

    public totalCount: number = 0;
    private currentState: any;
    private currentStatus: number = 0;

    public experiences: any[] = [];
    public priorities: any[] = [];
    public statuses: any[] = [];

    constructor(private vacanciesDataService: VacanciesDataService,
        private notificationService: NotificationService,
        private enumService: EnumDataService) {
    }

    ngOnInit() {
        let that = this;

        that.enumService.getEnums(EnumNames.EXPERIENCE).subscribe(
            data => {
                if (data) {
                    that.experiences = data.result;
                }
            }, error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, 'experienceLoadError');
            });

            that.enumService.getEnums(EnumNames.PRIORITY).subscribe(
                data => {
                    if (data) {
                        that.priorities = data.result;
                    }
                }, error => {
                    if (error.status == 400)
                        that.notificationService.notify(NotificationType.Error, 'priorityLoadError');
             });  

        that.enumService.getEnums(EnumNames.STATUSTYPE).subscribe(
            data => {
                if (data) {
                    that.statuses = data.result;
                }
            }, error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, 'statusLoadError');
            });
    }

    public getVacanciesByStatusType(event, status: number) {
        this.currentStatus = status;
        this.refresh(this.currentState);
    }

    public refresh(state: State) {
        let that = this;
        that.currentState = state;
        that.loading = true;
        
        let filters = that.getFiltersList(that.currentState.filters);

        let gridRequest: GridRequest = {
            take: that.currentState.page.size,
            skip: that.currentState.page.from,
             filters: filters
        };

        that.vacanciesDataService.getVacancies(that.currentStatus, gridRequest).subscribe(
            data => {
                that.vacanciesList = data.result;
                that.totalCount = data.totalCount;
                that.loading = false;
            },
            error => {
                that.loading = false;
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, 'vacanciesListLoadError');
            });

        that.selectedItems = [];
    }

    public changeStatus($event, vacancies: any[], status) {
        let that = this;

        that.vacanciesDataService.changeVacanciesStatus(vacancies.map(arr => arr.id), status).subscribe(
            data => {
                if (data) {
                    that.refresh(that.currentState);
                    that.notificationService.notify(NotificationType.Error,
                        vacancies.length === 1 ? 'vacancyChangeStatusSucces' : 'vacanciesChangeStatusSucces');
                }
            },
            error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error,
                        'vacancyChangeStatusError');
            });

    }

    public getFiltersList(stateFilters: Filter<any>[]): any[] {
        let filterList: any[] = [];

        if (stateFilters) {
            for (let item of stateFilters) {
                    filterList = filterList.concat(item['filter']);
            }
        }
        return filterList;
    }

}