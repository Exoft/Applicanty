import { Component, Input, OnInit, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';

import { State, Comparator, Filter } from '@clr/angular';

import { VacanciesDataService } from '../../services/vacancies-data.service';
import { NotificationService } from '../../../../services/notification.service';
import { StatusCommands } from '../../../../constants/status-commands';
import { EnumNames } from '../../../../constants/enum-names';
import { NotificationType } from '../../../../enums/notification-type';
import { EnumDataService } from '../../../../services/enum.data.service';
import { GridFilterItem } from '../../../filters/grid-filter-item';
import { GridRequest } from '../../../../services/grid-request';
import { FilterOperators } from '../../../../constants/filter-opertors';

@Component({
    templateUrl: './vacancies-list.component.html',
    styleUrls: ['./vacancies-list.component.scss'],
})
export class VacanciesListComponent implements OnInit {
    public selectedItems: any[] = [];

    public loading = true;

    public vacanciesList: any[] = [];

    public deleted = StatusCommands.DELETED;
    public archived = StatusCommands.ARCHIVED;
    public active = StatusCommands.ACTIVE;

  public totalCount = 0;
    private currentState: any;
  private currentStatus = 0;

    public experiences: any[] = [];
    public priorities: any[] = [];
    public statuses: any[] = [];

    constructor(private vacanciesDataService: VacanciesDataService,
        private notificationService: NotificationService,
        private enumService: EnumDataService) {
    }

    ngOnInit() {

        this.enumService.getEnums(EnumNames.EXPERIENCE).subscribe(
            data => {
                if (data) {
                    this.experiences = data.result;
                }
            }, error => {
                if (error.status === 400) {
                    this.notificationService.notify(NotificationType.Error, 'experienceLoadError');
                }
            });

        this.enumService.getEnums(EnumNames.PRIORITY).subscribe(
            data => {
                if (data) {
                    this.priorities = data.result;
                }
            }, error => {
                if (error.status === 400) {
                    this.notificationService.notify(NotificationType.Error, 'priorityLoadError');
                }
            });

        this.enumService.getEnums(EnumNames.STATUSTYPE).subscribe(
            data => {
                if (data) {
                    this.statuses = data.result;
                }
            }, error => {
                if (error.status === 400) {
                    this.notificationService.notify(NotificationType.Error, 'statusLoadError');
                }
            });
    }

    public getVacanciesByStatusType(event, status: number) {
        this.currentStatus = status;
        this.refresh(this.currentState);
    }

    public refresh(state: any) {
        this.currentState = state;
        this.loading = true;

        const filters = this.getFiltersList(this.currentState.filters);

        const gridRequest: GridRequest = {
            take: this.currentState.page.size,
            skip: this.currentState.page.from,
            filters: filters
        };

        this.vacanciesDataService.getVacancies(this.currentStatus, gridRequest).subscribe(
            data => {
                this.vacanciesList = data.result;
                this.totalCount = data.totalCount;
                this.loading = false;
            },
            error => {
                this.loading = false;
                if (error.status === 400) {
                    this.notificationService.notify(NotificationType.Error, 'vacanciesListLoadError');
                }
            });

        this.selectedItems = [];
    }

    public changeStatus($event, vacancies: any[], status) {

        this.vacanciesDataService.changeVacanciesStatus(vacancies.map(arr => arr.id), status).subscribe(
            data => {
                if (data) {
                    this.refresh(this.currentState);
                    this.notificationService.notify(NotificationType.Error,
                        vacancies.length === 1 ? 'vacancyChangeStatusSucces' : 'vacanciesChangeStatusSucces');
                }
            },
            error => {
                if (error.status === 400) {
                    this.notificationService.notify(NotificationType.Error, 'vacancyChangeStatusError');
                }
            });

    }

    public getFiltersList(stateFilters: any[]): any[] {
        let filterList: any[] = [];

        if (stateFilters) {
            for (const item of stateFilters) {
                filterList = filterList.concat(item['filter']);
            }
        }
        return filterList;
    }

}
