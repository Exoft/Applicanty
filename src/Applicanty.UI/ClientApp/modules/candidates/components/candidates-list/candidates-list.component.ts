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
    private skip: number = 0;
    private take: number = 30;
    total: number;
    loading: boolean = true;
    private totalCount: number;

    constructor(private сandidatesDataService: CandidatesDataService) {
    }
    
    refresh(state: State) {
        this.loading = true;

        this.сandidatesDataService.getCandidates(this.skip, this.take).subscribe(
            data => {
                this.candidates = data.result;
                this.totalCount = data.totalCount;
                this.loading = false;
            },
            error => {
                this.loading = false;
            });
        console.log(this.candidates);
    }
}