import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { ActivatedRoute } from '@angular/router';
import { VacanciesDataService } from '../../services/vacancies-data.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
    templateUrl: './vacancy-page.component.html',
    styleUrls: ['./vacancy-page.component.scss']
})
export class VacancyPageComponent implements OnInit, OnDestroy {

    public ckeditorContent;

    private id;
    private subscription: Subscription;

    public vacancyPageForm: FormGroup = new FormGroup({
        id: new FormControl(),
        title: new FormControl(),
        createDate: new FormControl(),
        endDate: new FormControl(),
        technologies: new FormControl(),
        experienceId: new FormControl(),
        vacancyDescription: new FormControl(),
        jobDescription: new FormControl()
    });

    constructor(private http: VacanciesDataService,
        private activeRoute: ActivatedRoute) {

        this.subscription = activeRoute.params.subscribe(params => this.id = params['id']);
    }

    ngOnInit() {
        this.http.getVacancy(this.id).subscribe(data => {
            var endDate = new Date(data.endDate);
            var createDate = new Date(data.createDate);
            if (data) {
                this.vacancyPageForm = new FormGroup({
                    id: new FormControl(data.id),
                    title: new FormControl(data.title, [Validators.required]),
                    createDate: new FormControl(createDate.toDateString(), [Validators.required]), 
                    endDate: new FormControl(endDate.getFullYear() + '-' + endDate.getMonth() + 1 + '-' + (endDate.getDate().toString().length === 1 ? '0' + endDate.getDate().toString() : endDate.getDate())
                        , [Validators.required]),
                    technologies: new FormControl(data.technologies, [Validators.required]),
                    experienceId: new FormControl(data.experienceId, [Validators.required]),
                    vacancyDescription: new FormControl(data.vacancyDescription, [Validators.required]),
                    jobDescription: new FormControl(data.jobDescription, [Validators.required])
                });
            }
        });
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }
}