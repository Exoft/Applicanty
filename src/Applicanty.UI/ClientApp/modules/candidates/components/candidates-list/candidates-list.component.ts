import { Component } from '@angular/core';
import { CandidatesDataService } from '../../services/candidates-data.service';
import { State } from "clarity-angular";
import { Router } from "@angular/router";

@Component({
    templateUrl: './candidates-list.component.html',
    styleUrls: ['./candidates-list.component.scss']
})
export class CandidatesListComponent {
    public candidates = [];
    private curentPage;
    public total: number;
    public loading: boolean = true;
    private totalCount: number;

    constructor(private сandidatesDataService: CandidatesDataService,) {
    }

    refresh(state: State) {
        this.loading = true;
        let filters: { [prop: string]: any[] } = {};
        if (state.filters) {
            for (let filter of state.filters) {
                let { property, value } = <{ property: string, value: string }>filter;
                filters[property] = [value];
            }
        }

        this.curentPage = state.page;
        this.сandidatesDataService.getCandidates(this.curentPage.from, this.curentPage.size).subscribe(
            data => {
                this.candidates = data.result;
                this.totalCount = data.totalCount;
                this.loading = false;
            },
            error => {
                this.loading = false;
            });
    }
}