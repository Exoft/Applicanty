import { Component, Input } from '@angular/core';
import { CandidatesDataService } from '../../services/candidates-data.service';
import { State } from "clarity-angular";
import { Router } from "@angular/router";

@Component({
    templateUrl: './candidates-list.component.html',
    styleUrls: ['./candidates-list.component.scss']
})
export class CandidatesListComponent {
    public candidates = [];
    public total: number;
    public loading: boolean = true;
    public selectedCandidates: any[] = [];

    private totalCount: number;
    private curentPage;


    constructor(private сandidatesDataService: CandidatesDataService,) {
    }

    refresh(state: State) {
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
        that.сandidatesDataService.getCandidates(that.curentPage.from, that.curentPage.size).subscribe(
            data => {
                that.candidates = data.result;
                that.totalCount = data.totalCount;
                that.loading = false;
            },
            error => {
                that.loading = false;
            });
    }
}