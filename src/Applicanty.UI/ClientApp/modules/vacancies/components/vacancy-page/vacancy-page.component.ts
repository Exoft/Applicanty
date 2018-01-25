import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { ActivatedRoute, Router } from '@angular/router';
import { VacanciesDataService } from '../../services/vacancies-data.service';
import { EnumDataService } from '../../../../services/enum.data.service';
import { EnumNames } from '../../../../constants/enum-names';
import { FormGroup, FormControl, Validators } from '@angular/forms';

import { ValidationService } from "../../../../services/validation.service";
import { NotificationService } from "../../../../services/notification.service";
import { NotificationType } from "../../../../enums/notification-type";

@Component({
    templateUrl: './vacancy-page.component.html',
    styleUrls: ['./vacancy-page.component.scss']
})
export class VacancyPageComponent implements OnInit, OnDestroy {
    private id;
    private subscription: Subscription;

    public technologies: any[] = [];
    public experiences: any[] = [];
    public vacancyStages: any[] = [];

    private experienceEnum = EnumNames.EXPERIENCE;
    private stageEnum = EnumNames.VACANCYSTAGE;

    public vacancyPageForm: FormGroup = new FormGroup({
        'id': new FormControl(''),
        'title': new FormControl('', Validators.required),
        'createDate': new FormControl(new Date()),
        'endDate': new FormControl(new Date(), Validators.required),
        'technologies': new FormControl('', Validators.required),
        'experienceId': new FormControl('', Validators.required),
        'vacancyDescription': new FormControl('', [Validators.required, Validators.minLength(40)]),
        'jobDescription': new FormControl('', [Validators.required, Validators.minLength(40)])
    });

    constructor(private vacanciesDataService: VacanciesDataService,
        private enumService: EnumDataService,
        private activeRoute: ActivatedRoute,
        private router: Router,
        public validationService: ValidationService,
        private notificationService: NotificationService) {
        let that = this;

        that.subscription = activeRoute.params.subscribe(params => that.id = params['id']);
    }

    ngOnInit() {
        let that = this;

        if (that.id) {
            that.vacanciesDataService.getVacancy(that.id).subscribe(vacancy => {
                if (vacancy) {
                    that.setFormData(vacancy);
                }
            }, error => {
                that.notificationService.notify(NotificationType.Error, 'Vacancy details not loaded.');
            });
        }

        that.vacanciesDataService.getTechnologies().subscribe(data => {
            that.technologies = data;
        }, error => {
            that.notificationService.notify(NotificationType.Error, 'Technology list not loaded.');
        });

        that.enumService.getEnums(that.experienceEnum).subscribe(data => {
            that.experiences = data.result;
        }, error => {
            that.notificationService.notify(NotificationType.Error, 'Experience list not loaded.');
        });

        that.enumService.getEnums(that.stageEnum).subscribe(data => {
            that.vacancyStages = data.result;
        }, error => {
            that.notificationService.notify(NotificationType.Error, 'Vacancy stages not loaded.');
        });
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }

    private setFormData(vacancy) {
        var endDate = new Date(vacancy.endDate);
        var createDate = new Date(vacancy.createDate);

        this.vacancyPageForm.setValue({
            'id': vacancy.id,
            'title': vacancy.title,
            'createDate': createDate.toLocaleDateString('en-EN'),
            'endDate': endDate.getFullYear() + '-' + endDate.getMonth() + 1 + '-' + (endDate.getDate().toString().length === 1 ? '0' + endDate.getDate().toString() : endDate.getDate()),
            'technologies': vacancy.technologies,
            'experienceId': vacancy.experienceId,
            'vacancyDescription': vacancy.vacancyDescription,
            'jobDescription': vacancy.jobDescription
        });
    }

    public saveVacancyClick(event) {
        let that = this;

        let formData = that.vacancyPageForm.value;
        if (!that.id) {
            formData['id'] = 0;

            that.vacanciesDataService.createVacancy(formData).subscribe(
                data => {
                    that.router.navigate(['../vacancies']);
                },
                error => {
                });
        } else {
            that.vacanciesDataService.updateVacancy(formData).subscribe(
                data => {
                    that.router.navigate(['../vacancies']);
                },
                error => {
                    that.notificationService.notify(NotificationType.Error, 'Error occurred during saving vacancy changes.');
                });
        }
    }

    public cancelClick(event) {
        this.router.navigate(['../vacancies']);
    }

    public vacancyTechnologiesChange(event) {
        let id = event.target.value;

        let selectedTechnologies = this.vacancyPageForm.get('technologies')!.value;

        if (event.target.checked) {
            if (selectedTechnologies.indexOf(id) < 0) {
                selectedTechnologies.push(id);
            }
        }
        else {
            if (selectedTechnologies.indexOf(id) >= 0) {
                selectedTechnologies.splice(selectedTechnologies.indexOf(id), 1);
            }
        }

        this.vacancyPageForm.get('technologies')!.setValue(selectedTechnologies);

        this.vacancyPageForm.get('technologies')!.markAsDirty();
        this.vacancyPageForm.get('technologies')!.markAsTouched();

        this.vacancyPageForm.updateValueAndValidity();
    }
}