import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from "@angular/router";

import { Comparator, State, Filter } from '@clr/angular';

import { Subscription } from "rxjs/Subscription";

import { CandidatesDataService } from '../../services/candidates-data.service';
import { NotificationService } from "../../../../services/notification.service";
import { NotificationType } from '../../../../enums/notification-type';
import { StatusCommands } from '../../../../constants/status-commands';
import { EnumDataService } from "../../../../services/enum.data.service";
import { EnumNames } from "../../../../constants/enum-names";
import { TransformBirthDateToAgePipe } from "./transform-birthdate-to-age.pipe";
import { GridRequest } from "../../../../services/grid-request";

@Component({
    templateUrl: './candidates-list.component.html',
    styleUrls: ['./candidates-list.component.scss']
})
export class CandidatesListComponent {
    public sortCandidates = [];
    public candidates = [];
    public loading: boolean = true;
    public selectedCandidates: any[] = [];
    public deleted = StatusCommands.DELETED;
    public archived = StatusCommands.ARCHIVED;
    public active = StatusCommands.ACTIVE;

    private vacancyId: number = 0;
    private stageId: number = 0;
    private subscription: Subscription = new Subscription();

    public totalCount: number = 0;
    private sortField: { by: string | Comparator<any>, reverse: boolean } = { by: 'lastName', reverse: false };
    private currentState: any;
    private currentStatus: number = 0;

    public experiences: any;
    public statuses: any[] = [];

    constructor(private candidatesDataService: CandidatesDataService,
        private activeRoute: ActivatedRoute,
        private notificationService: NotificationService,
        private enumService: EnumDataService) {

    }

    ngOnInit() {
        let that = this;
        that.subscription = that.activeRoute.params.subscribe(
            params => {
                that.vacancyId = params['vacancyId'];
                that.stageId = params['stageId'];
            });

        that.enumService.getEnums(EnumNames.EXPERIENCE).subscribe(
            data => {
                if (data) {
                    that.experiences = data.result;
                }
            }, error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, 'experienceLoadError');
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

    public changeStatus($event, candidates, status) {
        let that = this;
        that.candidatesDataService.changeCandidateStatus(candidates.map(arr => arr.id), status).subscribe(
            data => {
                if (data) {
                    that.notificationService.notify(NotificationType.Success,
                        candidates.length === 1 ? 'candidateChangeStatusSucces' : 'candidatesChangeStatusSucces');

                    that.refresh(that.currentState);
                }
            },
            error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, 'candidateChangeStatusError');
            });
    };

    public refresh(state: State) {
        let that = this;
        that.currentState = state;
        that.loading = true;
        if (state.sort) {
            that.sortField = state.sort;
        }

        let filters = that.getFiltersList(that.currentState.filters);

        let gridRequest: GridRequest = {
            take: that.currentState.page.size,
            skip: that.currentState.page.from,
            sortField: that.sortField.by.toString(),
            sortDir: that.sortField.reverse == true ? 'desc' : 'asc',
            filters: filters
        };

        if (!that.vacancyId && !that.stageId) {
            that.candidatesDataService.getCandidates(that.currentStatus, gridRequest).subscribe(
                data => {
                    that.candidates = data.result;
                    that.totalCount = data.totalCount;
                    that.loading = false;
                },
                error => {
                    that.loading = false;
                    if (error.status === 400)
                        that.notificationService.notify(NotificationType.Error, 'candidatesListLoadError');

                });
        } else {
            that.candidatesDataService.getCandidateByVacancyStage(that.vacancyId, that.stageId).subscribe(
                data => {
                    that.candidates = data.result;
                    that.totalCount = data.totalCount;
                    that.loading = false;
                }),
                error => {
                    that.loading = false;
                    if (error.status === 400)
                        that.notificationService.notify(NotificationType.Error, 'candidatesListLoadError');
                }
        }

        that.selectedCandidates = [];
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
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