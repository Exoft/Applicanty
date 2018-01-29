import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { CandidatesDataService } from '../../services/candidates-data.service';
import { NotificationService } from "../../../../services/notification.service";

import { NotificationType } from '../../../../enums/notification-type';
import { StatusCommands } from '../../../../constants/status-commands';
import { State } from "clarity-angular";
import { Router, ActivatedRoute } from "@angular/router";
import { Subscription } from "rxjs/Subscription";

@Component({
    templateUrl: './candidates-list.component.html',
    styleUrls: ['./candidates-list.component.scss']
})
export class CandidatesListComponent implements OnInit, OnDestroy {
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

    public changeStatus($event, candidate, status) {
        let that = this;

        that.candidatesDataService.changeCandidateStatus([candidate.id], status).subscribe(data => {
            if (data) {
                that.notificationService.notify(NotificationType.Success, 'Success');
            }
        },
            error => {
                that.notificationService.notify(NotificationType.Error, 'Error');
            });
    }


    public refresh(state: State) {
        let that = this;

        that.loading = true;
        let filters: { [prop: string]: any[] } = {};

        if (state.filters) {
            for (let filter of state.filters) {
                let { property, value } = <{ property: string, value: string }>filter;
                filters[property] = [value];
            }
        }

        that.curentPage = state.page;
        if (!that.vacancyId && !that.stageId) {
            that.candidatesDataService.getCandidates(that.curentPage.from, that.curentPage.size).subscribe(
                data => {
                    that.candidates = data.result;
                    that.totalCount = data.totalCount;
                    that.loading = false;
                },
                error => {
                    that.loading = false;
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
                }
        }
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }
}