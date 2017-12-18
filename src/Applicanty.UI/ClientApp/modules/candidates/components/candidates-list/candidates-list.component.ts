import { Component } from '@angular/core';
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

    constructor(private сandidatesDataService: CandidatesDataService) {
    }
    
    refresh(state: State) {
        this.loading = true;

        this.сandidatesDataService.getCandidates().subscribe(
            result => {
                this.candidates = result;

                this.loading = false;
            },
            error => {
                this.loading = false;
            });
    }
}