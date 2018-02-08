import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { CandidatesDataService } from '../../services/candidates-data.service';
import { ValidationService } from '../../../../services/validation.service';
import { NotificationService } from '../../../../services/notification.service';
import { NotificationType } from "../../../../enums/notification-type";
import { EnumDataService } from '../../../../services/enum.data.service';
import { EnumNames } from '../../../../constants/enum-names';
import { NotificationMessage } from "../../../../constants/notification-message";
import { VacanciesDataService } from "../../../vacancies/services/vacancies-data.service";

@Component({
    templateUrl: './candidate-page.component.html',
    styleUrls: ['./candidate-page.component.scss']
})
export class CandidatePageComponent implements OnInit, OnDestroy {

    public setStageModalVisible: boolean = false;

    private id: number;
    private subscription: Subscription;

    private experienceEnumName = EnumNames.EXPERIENCE;
    private stageEnumName = EnumNames.VACANCYSTAGE;

    public experiences: any[] = [];
    public technologies: any[] = [];
    public vacancyStages: any[] = [];
    public vacancies: any[] = [];

    public candidatePageFrom: FormGroup = new FormGroup({
        'id': new FormControl(''),
        'experienceId': new FormControl(0, Validators.required),
        'firstName': new FormControl('', Validators.required),
        'lastName': new FormControl('', Validators.required),
        'technologyIds': new FormControl([], [Validators.required, this.validationService.technologiesValidator]),
        'email': new FormControl('', Validators.required),
        'skype': new FormControl('', Validators.required),
        'linkedIn': new FormControl(''),
        'phone': new FormControl(''),
        'cvPath': new FormControl(''),
        'birthday': new FormControl(new Date(), Validators.required)
    });

    public candidateAttachVacancyForm: any; 

    constructor(private candidatesDataService: CandidatesDataService,
        private vacanciesDataService: VacanciesDataService,
        private enumService: EnumDataService,
        private activeRoute: ActivatedRoute,
        public validationService: ValidationService,
        private router: Router,
        private notificationService: NotificationService) {

        let that = this;

        that.subscription = activeRoute.params.subscribe(params => {
            that.id = params['id'];

            that.candidateAttachVacancyForm = new FormGroup({
                'candidateId': new FormControl(that.id),
                'vacancyId': new FormControl('', Validators.required),
                'vacancyStage': new FormControl('', Validators.required)
            });
        });
    }

    ngOnInit() {
        let that = this;

        if (that.id) {
            that.candidatesDataService.getCandidate(that.id).subscribe(
                candidate => {
                    if (candidate) {
                        that.setFormData(candidate);
                    }
                },
                error => {
                    if (error.status == 400)
                        that.notificationService.notify(NotificationType.Error, NotificationMessage.CANDIDATEDETAILSLOADERROR);
                });
        }

        that.vacanciesDataService.getVacancies(0, 1000).subscribe(
            data => {
                that.vacancies = data['result'];
            },
            error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, NotificationMessage.VACANCIESLOADERROR);
            });

        that.enumService.getEnums(that.experienceEnumName).subscribe(
            data => {
                that.experiences = data.result;
            },
            error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, NotificationMessage.CANDIDATESSTAGELOADERROR);
            });

        that.enumService.getEnums(that.stageEnumName).subscribe(
            data => {
                that.vacancyStages = data.result;
            },
            error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, NotificationMessage.VACANCYSTAGELOADERROR);
            });

        that.candidatesDataService.getTechnologies().subscribe(
            data => {
                that.technologies = data;
            },
            error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, NotificationMessage.TECHNOLOGIESLOADERROR);
            });
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }

    private setFormData(candidate) {
        var birthdayDate = new Date(candidate.birthday);

        this.candidatePageFrom.setValue({
            'id': candidate.id,
            'experienceId': candidate.experienceId,
            'firstName': candidate.firstName,
            'lastName': candidate.lastName,
            'technologyIds': candidate.technologyIds ? candidate.technologyIds : [],
            'email': candidate.email,
            'skype': candidate.skype,
            'linkedIn': candidate.linkedIn,
            'phone': candidate.phone,
            'cvPath': candidate.cvPath,
            'birthday': birthdayDate.getFullYear() + '-' + ((birthdayDate.getMonth() + 1).toString().length === 1 ? '0' + (birthdayDate.getMonth() + 1).toString() : (birthdayDate.getMonth() + 1).toString()) + '-' + (birthdayDate.getDate().toString().length === 1 ? '0' + birthdayDate.getDate().toString() : birthdayDate.getDate())
        });
    }

    public vacancyTechnologiesChange(event) {
        let id = Number(event.target.value);

        let selectedTechnologies = this.candidatePageFrom.get('technologyIds')!.value;

        if (event.target.checked) {
            if (selectedTechnologies.indexOf(id) < 0) {
                selectedTechnologies.push(id);
            }
        } else {
            if (selectedTechnologies.indexOf(id) >= 0) {
                selectedTechnologies.splice(selectedTechnologies.indexOf(id), 1);
            }
        }

        this.candidatePageFrom.get('technologyIds')!.setValue(selectedTechnologies);

        this.candidatePageFrom.get('technologyIds')!.markAsDirty();
        this.candidatePageFrom.get('technologyIds')!.markAsTouched();

        this.candidatePageFrom.updateValueAndValidity();
    }

    public saveCandidateClick(event) {
        let that = this;

        let formData = that.candidatePageFrom.value;

        if (!that.id) {
            formData['id'] = 0;

            that.candidatesDataService.createCandidate(formData).subscribe(
                data => {
                    that.router.navigate(['../candidates']);
                },
                error => {
                    if (error.status == 400)
                        that.notificationService.notify(NotificationType.Error, NotificationMessage.CREATECANDIDATEERROR);
                });
        } else {
            that.candidatesDataService.updateCandidate(formData).subscribe(
                data => {
                    that.router.navigate(['../candidates']);
                },
                error => {
                    if (error.status == 400)
                        that.notificationService.notify(NotificationType.Error, NotificationMessage.CANDIDATECHANGESTATUSERROR);
                });
        }
    }

    public cancelClick(event) {
        this.router.navigate(['../candidates']);
    }

    public showModal(event) {
        this.setStageModalVisible = true;
    }
    
    public attachToVacancyClick(event) {
        if (this.candidateAttachVacancyForm.valid) {
            debugger;
        }
    }
}