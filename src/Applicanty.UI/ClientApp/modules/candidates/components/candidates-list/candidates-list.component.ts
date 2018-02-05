import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { CandidatesDataService } from '../../services/candidates-data.service';
import { NotificationService } from "../../../../services/notification.service";

import { NotificationType } from '../../../../enums/notification-type';
import { NotificationMassage } from "../../../../constants/notification-message";
import { Comparator } from "clarity-angular";
import { StatusCommands } from '../../../../constants/status-commands';
import { State } from "clarity-angular";
import { Router, ActivatedRoute } from "@angular/router";
import { Subscription } from "rxjs/Subscription";

@Component({
    templateUrl: './candidates-list.component.html',
    styleUrls: ['./candidates-list.component.scss']
})
export class CandidatesListComponent {
    public sortCandidates = [];
    public candidates = [];
    public total: number;
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

    constructor(private candidatesDataService: CandidatesDataService,
        private activeRoute: ActivatedRoute,
        private notificationService: NotificationService) {

    }

    ngOnInit() {
        let that = this;
        that.subscription = that.activeRoute.params.subscribe(
            params => {
                that.vacancyId = params['vacancyId'];
                that.stageId = params['stageId'];
                console.log(that.vacancyId + that.stageId);
            });
    }

    public changeStatus($event, candidates, status) {
        let that = this;
        let message = candidates.length === 1 ? 'Candidate ' : 'Candidates ';

        that.candidatesDataService.changeCandidateStatus(candidates.map(arr => arr.id), status).subscribe(
            data => {
                if (data) {
                    that.notificationService.notify(NotificationType.Success,
                        candidates.length === 1 ? NotificationMassage.CANDIDATECHANGESTATUSSUCCES : NotificationMassage.CANDIDATESCHANGESTATUSSUCCES);
                }
            },
            error => {
                that.notificationService.notify(NotificationType.Error,
                    candidates.length === 1 ? NotificationMassage.CANDIDATECHANGESTATUSERROR : NotificationMassage.CANDIDATESCHANGESTATUSERROR);
            });
    };

    public refresh(state: State) {
        let that = this;
        that.loading = true;

        that.curentPage = state.page;

        if (state.sort)
            that.sortField = state.sort;

        that.candidatesDataService.getCandidates(that.curentPage.from, that.curentPage.size,
            that.sortField.by.toString(), that.sortField.reverse === true ? 'desc' : 'asc').subscribe(
            data => {
                that.candidates = data.result;
                that.totalCount = data.totalCount;
                that.loading = false;
            },
            error => {
                that.loading = false;
                that.notificationService.notify(NotificationType.Error, NotificationMassage.CANDIDATESLISTLOADERROR);
            });
    }
}