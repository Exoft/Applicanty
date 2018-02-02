import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Subscription } from 'rxjs/Subscription';
import { ActivatedRoute, Router } from '@angular/router';
import { VacanciesDataService } from '../../services/vacancies-data.service';
import { EnumDataService } from '../../../../services/enum.data.service';
import { EnumNames } from '../../../../constants/enum-names';
import { NotificationMassage } from '../../../../constants/notification-message';

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
    public vacancyStageCount: { [value: number]: any } = {};

    private experienceEnum = EnumNames.EXPERIENCE;
    private stageEnum = EnumNames.VACANCYSTAGE;

    public vacancyPageForm: FormGroup = new FormGroup({
        'id': new FormControl(''),
        'title': new FormControl('', Validators.required),
        'createdBy': new FormControl(1),
        'createdAt': new FormControl(new Date().toLocaleDateString()),
        'endDate': new FormControl(new Date(), [Validators.required, this.validationService.endDateValidator]),
        'technologiesId': new FormControl([], [Validators.required, this.validationService.technologiesValidator]),
        'experienceId': new FormControl(0, Validators.required),
        'vacancyDescription': new FormControl('', [Validators.required, Validators.minLength(20)]),
        'jobDescription': new FormControl('', [Validators.required, Validators.minLength(20)])
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
            that.vacanciesDataService.getVacancy(that.id).subscribe(
                vacancy => {
                    if (vacancy) {
                        that.setFormData(vacancy);
                    }
                }, error => {
                    that.notificationService.notify(NotificationType.Error, NotificationMassage.VACANCYDETAILSLOADERROR);
                });

            that.enumService.getEnums(that.stageEnum).subscribe(
                data => {
                    that.vacancyStages = data.result;
                }, error => {
                    that.notificationService.notify(NotificationType.Error, NotificationMassage.VACANCYSTAGELOADERROR);
                });

            that.vacanciesDataService.getVacancyStagesCount(that.id).subscribe(
                data => {
                    if (data) {
                        for (let statusCount of data) {
                            let { stage, count } = <{ stage: number, count: any }>statusCount;
                            that.vacancyStageCount[stage] = count;
                        }
                    }
                }, error => {
                    that.notificationService.notify(NotificationType.Error, NotificationMassage.VACANCYSTAGESCOUNTLOADERROR);
                });
        }

        that.vacanciesDataService.getTechnologies().subscribe(
            data => {
                that.technologies = data;
            }, error => {
                that.notificationService.notify(NotificationType.Error, NotificationMassage.TECHNOLOGIESLOADERROR);
            });

        that.enumService.getEnums(that.experienceEnum).subscribe(
            data => {
                that.experiences = data.result;
            }, error => {
                that.notificationService.notify(NotificationType.Error, NotificationMassage.EXPERIENCELOADERROR);
            });

    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }

    private setFormData(vacancy) {
        var endDate = new Date(vacancy.endDate);
        var createDate = new Date(vacancy.createdAt);
        this.vacancyPageForm.setValue({
            'id': vacancy.id,
            'title': vacancy.title,
            'createdBy': Number(vacancy.createdBy),
            'createdAt': createDate.toLocaleDateString(),
            'endDate': endDate.getFullYear() + '-' + ((endDate.getMonth() + 1).toString().length === 1 ? '0' + (endDate.getMonth() + 1).toString() : (endDate.getMonth() + 1).toString()) + '-' + (endDate.getDate().toString().length === 1 ? '0' + endDate.getDate().toString() : endDate.getDate()),
            'technologiesId': vacancy.technologiesId,
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
                    that.notificationService.notify(NotificationType.Error, NotificationMassage.CREATEVACANCYERROR);
                });
        } else {
            that.vacanciesDataService.updateVacancy(formData).subscribe(
                data => {
                    that.router.navigate(['../vacancies']);
                },
                error => {
                    that.notificationService.notify(NotificationType.Error, NotificationMassage.UPDATEVACANCYERROR);
                });
        }
    }

    public cancelClick(event) {
        this.router.navigate(['../vacancies']);
    }

    public vacancyTechnologiesChange(event) {
        let id = Number(event.target.value);


        let selectedTechnologies = this.vacancyPageForm.get('technologiesId')!.value;

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

        this.vacancyPageForm.get('technologiesId')!.setValue(selectedTechnologies);

        this.vacancyPageForm.get('technologiesId')!.markAsDirty();
        this.vacancyPageForm.get('technologiesId')!.markAsTouched();

        this.vacancyPageForm.updateValueAndValidity();

    }

    public vacancyStageLabelClick(event: Event, idStage: number) {
        event.preventDefault();

        if (this.vacancyStageCount[idStage] !== 0) {
            this.router.navigate(['../', 'candidates', 'vacancy', this.id, 'stage', idStage]);
        }
    }
}