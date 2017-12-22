import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { ActivatedRoute } from '@angular/router';
import { VacanciesDataService } from '../../services/vacancies-data.service';

@Component({
    selector: 'vacancy-page',
    templateUrl: './vacancy-page.component.html',
    styleUrls: ['./vacancy-page.component.scss']
})
export class VacancyPageComponent implements OnInit, OnDestroy {

    public vacancy;

    private id;
    private subscription: Subscription;

    constructor(private http: VacanciesDataService,
        private activeRoute: ActivatedRoute) {

        this.subscription = activeRoute.params.subscribe(
            params => this.id = params['vacancyId']);
    }

    ngOnInit() {
        this.http.getVacancy(this.id).subscribe(item => this.vacancy = item);
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }
}