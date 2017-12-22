﻿import { Component } from '@angular/core';
import { CandidatesDataService } from '../../services/candidates-data.service';
import { State } from "clarity-angular";

@Component({
    templateUrl: './candidates-list.component.html',
    styleUrls: ['./candidates-list.component.scss']
})
export class CandidatesListComponent {
    candidates = [];
    total: number;
    loading: boolean = true;
    private totalCount: number;

    constructor(private сandidatesDataService: CandidatesDataService) {
    }
    
    refresh(state: State) {
        this.loading = true;

        this.сandidatesDataService.getCandidates().subscribe(
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