import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { ActivatedRoute } from '@angular/router';
import { CandidatesDataService } from '../../services/candidates-data.service';

@Component({
    selector: 'candidate',
    templateUrl: './candidate-page.component.html',
    styleUrls: ['./candidate-page.component.scss']
})
export class CandidatePageComponent implements OnInit {
    candidate;
    private id;
    private subscription: Subscription;
    constructor(private http: CandidatesDataService,
        private activeRoute: ActivatedRoute) {
        this.subscription = activeRoute.params.subscribe(
            params => this.id = params['candidateId']);
    }

    ngOnInit() {
        this.http.getCandidate(this.id).subscribe(item => this.candidate = item);
    }
}