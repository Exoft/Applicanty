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
import { VacanciesDataService } from "../../../vacancies/services/vacancies-data.service";
import { Observable } from "rxjs/Observable";
import 'rxjs/add/observable/forkJoin';

@Component({
    templateUrl: './candidate-page.component.html',
    styleUrls: ['./candidate-page.component.scss']
})
export class CandidatePageComponent implements OnInit, OnDestroy {

    public setStageModalVisible: boolean = false;

    private id: number = 0;
    private subscription: Subscription = new Subscription();
    private experienceId: number = 0;
    private technologyIds: any[] = [];

    private experienceEnumName = EnumNames.EXPERIENCE;
    private stageEnumName = EnumNames.VACANCYSTAGE;

    public experiences: any[] = [];
    public technologies: any[] = [];
    public vacancyStages: any[] = [];
    public vacancies: any[] = [];
    public candidateVacancyStage: any[] = [];
    public vacanciesOfCadidate: any[] = [];
    public vacanciesForTheChoice: any[] = [];
    public selectedVacanciesOfCandidate: any[] = [];
    public candidateVacancy: any[] = [];

    public candidatePageFrom: FormGroup = new FormGroup({
        'id': new FormControl(''),
        'experienceId': new FormControl(0, Validators.required),
        'firstName': new FormControl('', Validators.required),
        'lastName': new FormControl('', Validators.required),
        'technologyIds': new FormControl([]),
        'email': new FormControl('', Validators.required),
        'skype': new FormControl('', Validators.required),
        'linkedIn': new FormControl(''),
        'phone': new FormControl(''),
        'cvPath': new FormControl(''),
        'birthday': new FormControl(new Date(), Validators.required)
    });

    public candidateAttachVacancyForm: FormGroup = new FormGroup({
        'vacancyId': new FormControl('', Validators.required),
        'vacancyStage': new FormControl('', Validators.required)
    });

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
        });
    }

    ngOnInit() {
        let that = this;

        if (that.id) {
            that.candidatesDataService.getCandidate(that.id).subscribe(
                candidate => {
                    if (candidate) {
                        that.setFormData(candidate);
                        that.experienceId = candidate.experienceId;
                        that.technologyIds = candidate.technologyIds ? candidate.technologyIds : [];
                    }
                },
                error => {
                    if (error.status == 400)
                        that.notificationService.notify(NotificationType.Error, 'candidateDetailsLoadError');
                });

        }

        that.enumService.getEnums(that.experienceEnumName).subscribe(
            data => {
                that.experiences = data.result;
            },
            error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, 'experienceLoadError');
            });

        that.enumService.getEnums(that.stageEnumName).subscribe(
            data => {
                that.vacancyStages = data.result;
            },
            error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, 'vacancyStageLoadError');
            });

        that.candidatesDataService.getTechnologies().subscribe(
            data => {
                that.technologies = data;
            },
            error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, 'technologiesLoadError');
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
                        that.notificationService.notify(NotificationType.Error, 'createCandidateError');
                });
        } else {
            that.candidatesDataService.updateCandidate(formData).subscribe(
                data => {
                    that.router.navigate(['../candidates']);
                },
                error => {
                    if (error.status == 400)
                        that.notificationService.notify(NotificationType.Error, 'candidateChangeStatusError');
                });
        }
    }

    public cancelClick(event) {
        this.router.navigate(['../candidates']);
        this.vacancies = [];
    }

    public showModal(event) {
        this.setStageModalVisible = true;
        let that = this;

        let formData = that.candidatePageFrom.value;

        Observable.forkJoin(
            that.candidatesDataService.getByCandidate(that.id),
            that.candidatesDataService.getVacancyByTechnologyAndExperience(that.experienceId, that.technologyIds))
            .subscribe(
            data => {
                that.vacanciesOfCadidate = data[0];
                that.vacanciesForTheChoice = data[1];

                let idArray = that.vacanciesOfCadidate.filter(function (el, index, array) {
                    return el.id;
                });
                that.vacanciesForTheChoice.forEach(function (el, index, arr) {
                    if (!idArray.some(item => item.id === el.id)) {
                        that.vacancies.push(el);
                    }
                })
            });

        that.candidatesDataService.updateCandidate(formData).subscribe(
            data => {
            },
            error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, 'candidateChangeStatusError');
            });
    }
    
    public attachToVacancyClick(event) {
        let that = this;
        if (that.candidateAttachVacancyForm.valid) {
            let formData = that.candidateAttachVacancyForm.value;
            that.candidatesDataService.attachCandidateStageToVacancy({
                'candidateId': that.id,
                'vacancyId': Number(formData.vacancyId),
                'vacancyStage': Number(formData.vacancyStage)
            }).subscribe(
                data => {
                    that.setStageModalVisible = false;
                    that.refreshCurrentVacancyList();
                },
                error => {
                    if (error.status == 400)
                        that.notificationService.notify(NotificationType.Error, 'attachCandidateStageToVacancyError');
                });
        }
    }

    public deleteVacancyClick(event) {
        let that = this;

        if (that.getSelectedVacancies()) {
            let arr = that.getSelectedVacancies();
            for (let item of arr) {
                that.candidatesDataService.detachVacancy(item).subscribe(
                    data => {
                        that.refreshCurrentVacancyList();
                    });
            }
        }
    }

    public refreshCurrentVacancyList() {
        let that = this;

        that.candidatesDataService.getByCandidate(that.id).subscribe(
            data => {
                that.candidateVacancyStage = data;
            },
            error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, 'candidatesListLoadError');
            });
        that.selectedVacanciesOfCandidate = [];
        that.vacancies = [];
        that.clearCandidateAttachVacancyForm();
    }

    private getSelectedVacancies() {
        let selectedCandidateList: any[] = [];
        for (let item of this.selectedVacanciesOfCandidate) {
            selectedCandidateList = selectedCandidateList.concat({
                "vacancyId": item.id,
                "candidateId": this.id,
                "vacancyStage": item.vacancyStage
            })
        }
        return selectedCandidateList;
    }

    clearCandidateAttachVacancyForm() {
        this.candidateAttachVacancyForm.get('vacancyId')!.setValue(null);
        this.candidateAttachVacancyForm.get('vacancyStage')!.setValue(null);
    }
}