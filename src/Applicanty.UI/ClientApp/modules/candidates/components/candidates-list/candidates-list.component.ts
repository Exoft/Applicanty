﻿import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { CandidatesDataService } from '../../services/candidates-data.service';
import { NotificationService } from "../../../../services/notification.service";
import { NotificationType } from '../../../../enums/notification-type';
import { NotificationMassage } from "../../../../constants/notification-message";
import { Comparator } from "clarity-angular";
import { StatusCommands } from '../../../../constants/status-commands';
import { State } from "clarity-angular";
import { Router, ActivatedRoute } from "@angular/router";
import { Subscription } from "rxjs/Subscription";
import { EnumDataService } from "../../../../services/enum.data.service";
import { EnumNames } from "../../../../constants/enum-names";
import { TransformBirthDateToAgePipe } from "./transform-birthdate-to-age.pipe";

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

    private vacancyId: number;
    private stageId: number;
    private subscription: Subscription;

    private totalCount: number;
    private curentPage;
    private sortField: { by: string | Comparator<any>, reverse: boolean } = { by: 'lastName', reverse: false };
    private currentState;
    private currentStatus: number = 0;

    private experiences: { [value: number]: any } = {};
    private statuses;

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
                    for (let experience of data.result) {
                        let { value, name } = <{ value: number, name: string }>experience;
                        that.experiences[value] = name;
                    }
                }
            }, error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, NotificationMassage.EXPERIENCELOADERROR);
            });

        that.enumService.getEnums(EnumNames.STATUSTYPE).subscribe(
            data => {
                if (data) {
                    that.statuses = data.result;
                }
            }, error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, NotificationMassage.STATUSLOADERROR);
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
                        candidates.length === 1 ? NotificationMassage.CANDIDATECHANGESTATUSSUCCES : NotificationMassage.CANDIDATESCHANGESTATUSSUCCES);
                    that.refresh(that.currentState);
                }
            },
            error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error,
                        candidates.length === 1 ? NotificationMassage.CANDIDATECHANGESTATUSERROR : NotificationMassage.CANDIDATESCHANGESTATUSERROR);
            });
    };

    public refresh(state: State) {
        let that = this;
        that.currentState = state;
        that.loading = true;
        that.curentPage = state.page;
        if (state.sort)
            that.sortField = state.sort;
        if (!that.vacancyId && !that.stageId) {
            that.candidatesDataService.getCandidates(that.curentPage.from, that.curentPage.size,
                that.sortField.by.toString(), that.sortField.reverse === true ? 'desc' : 'asc', that.currentStatus).subscribe(
                data => {
                    that.candidates = data.result;
                    that.totalCount = data.totalCount;
                    that.loading = false;
                },
                error => {
                    that.loading = false;
                    if (error.status === 400)
                        that.notificationService.notify(NotificationType.Error, NotificationMassage.CANDIDATESLISTLOADERROR);

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
                        that.notificationService.notify(NotificationType.Error, NotificationMassage.CANDIDATESLISTLOADERROR);
                }
        }
        that.selectedCandidates = [];
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }
}