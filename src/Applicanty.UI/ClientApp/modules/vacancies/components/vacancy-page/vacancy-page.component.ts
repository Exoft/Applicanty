import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Subscription } from 'rxjs/Subscription';
import { ActivatedRoute, Router } from '@angular/router';
import { VacanciesDataService } from '../../services/vacancies-data.service';
import { EnumDataService } from '../../../../services/enum.data.service';
import { EnumNames } from '../../../../constants/enum-names';
import { NotificationMessage } from '../../../../constants/notification-message';

import { ValidationService } from "../../../../services/validation.service";
import { NotificationService } from "../../../../services/notification.service";
import { NotificationType } from "../../../../enums/notification-type";
import { Observable } from "rxjs/Observable";
import 'rxjs/add/observable/forkJoin';

@Component({
    templateUrl: './vacancy-page.component.html',
    styleUrls: ['./vacancy-page.component.scss']
})
export class VacancyPageComponent implements OnInit, OnDestroy {
    private setStageModalVisible: boolean = false;
    private id;
    private subscription: Subscription = new Subscription();

    public technologies: any[] = [];
    public experiences: any[] = [];
    public vacancyStages: any[] = [];
    public selectedCandidatesOfVacancy: any[] = [];
    public vacancyStageCount: { [value: number]: any } = {};
    public candidatesByVacancy: any[] = [];
    public candidateByTechnologyAndExperience: any[] = [];
    public addedCandidates: any[] = [];
    public availableCandidatesForSelection: any[] = [];

    public froalaOptions: Object = {
        charCounterCount: true,
        toolbarButtons: ['bold', 'italic', 'underline', '|', 'fontFamily', 'fontSize', '|', 'align', 'formatOL', 'formatUL', '|', 'selectAll', 'clearFormatting', '|', 'undo', 'redo'],
        toolbarButtonsXS: ['bold', 'italic', 'underline', '|', 'fontFamily', 'fontSize', '|', 'align', '|', 'undo', 'redo'],
        toolbarButtonsSM: ['bold', 'italic', 'underline', '|', 'fontFamily', 'fontSize', '|', 'align', '|', 'undo', 'redo'],
        toolbarButtonsMD: ['bold', 'italic', 'underline', '|', 'fontFamily', 'fontSize', '|', 'align', '|', 'undo', 'redo'],
    };

    private experienceEnum = EnumNames.EXPERIENCE;
    private stageEnum = EnumNames.VACANCYSTAGE;

    public vacancyPageForm: FormGroup = new FormGroup({
        'id': new FormControl(''),
        'title': new FormControl('', Validators.required),
        'createdBy': new FormControl(''),
        'createdAt': new FormControl(new Date().toLocaleDateString()),
        'endDate': new FormControl(new Date(), [Validators.required, this.validationService.endDateValidator]),
        'technologyIds': new FormControl([], [Validators.required, this.validationService.technologiesValidator]),
        'experienceId': new FormControl(0, Validators.required),
        'vacancyDescription': new FormControl('', [Validators.required, Validators.minLength(20)]),
        'jobDescription': new FormControl('', [Validators.required, Validators.minLength(20)])
    });


    public candidateAttachVacancyForm: FormGroup = new FormGroup({
        'candidateId': new FormControl('', Validators.required),
        'vacancyStage': new FormControl('', Validators.required)
    })


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
                    if (error.status == 400)
                        that.notificationService.notify(NotificationType.Error, NotificationMessage.VACANCYDETAILSLOADERROR);
                });

            that.enumService.getEnums(that.stageEnum).subscribe(
                data => {
                    that.vacancyStages = data.result;
                }, error => {
                    if (error.status == 400)
                        that.notificationService.notify(NotificationType.Error, NotificationMessage.VACANCYSTAGELOADERROR);
                });

            that.refreshVacancyStageCount();
        }

        that.vacanciesDataService.getTechnologies().subscribe(
            data => {
                that.technologies = data;
            }, error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, NotificationMessage.TECHNOLOGIESLOADERROR);
            });

        that.enumService.getEnums(that.experienceEnum).subscribe(
            data => {
                that.experiences = data.result;
            }, error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, NotificationMessage.EXPERIENCELOADERROR);
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
            'createdAt': createDate.getFullYear() + '-' + ((createDate.getMonth() + 1).toString().length === 1 ? '0' + (createDate.getMonth() + 1).toString() : (createDate.getMonth() + 1).toString()) + '-' + (createDate.getDate().toString().length === 1 ? '0' + createDate.getDate().toString() : createDate.getDate()),
            'endDate': endDate.getFullYear() + '-' + ((endDate.getMonth() + 1).toString().length === 1 ? '0' + (endDate.getMonth() + 1).toString() : (endDate.getMonth() + 1).toString()) + '-' + (endDate.getDate().toString().length === 1 ? '0' + endDate.getDate().toString() : endDate.getDate()),
            'technologyIds': vacancy.technologyIds,
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
                    if (error.status == 400)
                        that.notificationService.notify(NotificationType.Error, NotificationMessage.CREATEVACANCYERROR);
                });
        } else {
            that.vacanciesDataService.updateVacancy(formData).subscribe(
                data => {
                    that.router.navigate(['../vacancies']);
                },
                error => {
                    if (error.status == 400)
                        that.notificationService.notify(NotificationType.Error, NotificationMessage.UPDATEVACANCYERROR);
                });
        }
    }

    public cancelClick(event) {
        this.router.navigate(['../vacancies']);
        this.candidateByTechnologyAndExperience = [];
    }

    public vacancyTechnologiesChange(event) {
        let id = Number(event.target.value);

        let selectedTechnologies = this.vacancyPageForm.get('technologyIds')!.value;

        if (event.target.checked) {
            if (selectedTechnologies.indexOf(id) < 0) {
                selectedTechnologies.push(id);
            }
        } else {
            if (selectedTechnologies.indexOf(id) >= 0) {
                selectedTechnologies.splice(selectedTechnologies.indexOf(id), 1);
            }
        }

        this.vacancyPageForm.get('technologyIds')!.setValue(selectedTechnologies);

        this.vacancyPageForm.get('technologyIds')!.markAsDirty();
        this.vacancyPageForm.get('technologyIds')!.markAsTouched();

        this.vacancyPageForm.updateValueAndValidity();
    }

    public vacancyStageLabelClick(event: Event, idStage: number) {
        event.preventDefault();

        if (this.vacancyStageCount[idStage]) {
            this.router.navigate(['../', 'candidates', 'vacancy', this.id, 'stage', idStage]);
        }
    }

    public showAvailableCandidates(event) {
        let that = this;
        let formData = that.vacancyPageForm.value;

        let technologyIds = that.vacancyPageForm.get('technologyIds')!.value;
        let experienceId = that.vacancyPageForm.get('experienceId')!.value;

        Observable.forkJoin(
            that.vacanciesDataService.getCandidateByVacancy(that.id),
            that.vacanciesDataService.candidateGetByTechnologyAndExperience(experienceId, technologyIds))
            .subscribe(
            data => {
                that.addedCandidates = data[0].result;
                that.availableCandidatesForSelection = data[1];

                let idArray = that.addedCandidates.filter(function (el, index, array) {
                    return el.id;
                });
                that.availableCandidatesForSelection.forEach(function (el, index, arr) {
                    if (!idArray.some(item => item.id === el.id)) {
                        that.candidateByTechnologyAndExperience.push(el);
                    }
                })

                that.setStageModalVisible = true;
            });

        that.vacanciesDataService.updateVacancy(formData).subscribe(
            data => {
            });
    }

    public attachToCandidateClick(event) {
        let that = this;
        let formData = that.candidateAttachVacancyForm.value;
        that.vacanciesDataService.attachVacancyToCandidateStage({
            'vacancyId': that.id,
            'candidateId': Number(formData.candidateId),
            'vacancyStage': Number(formData.vacancyStage)
        }).subscribe(
            data => {
                that.refreshCurrentVacancyList();
                that.setStageModalVisible = false;
                that.refreshVacancyStageCount();
            })
    }

    public deleteCandydateClick(event) {
        let that = this;
        
        if (that.getSelectedVacancies()) {
            let arr = that.getSelectedVacancies();
            for (let item of arr) {
                that.vacanciesDataService.detachCandidate(item).subscribe(
                    data => {
                        that.refreshCurrentVacancyList();
                    });
            }
        }
    }

    private refreshCurrentVacancyList() {
        let that = this;

        that.vacanciesDataService.getCandidateByVacancy(that.id).subscribe(
            data => {
                that.candidatesByVacancy = data.result;
            },
            error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, NotificationMessage.CANDIDATESLISTLOADERROR);
            });

        that.selectedCandidatesOfVacancy = [];
        that.clearCandidateAttachVacancyForm();
        that.refreshVacancyStageCount();
    }

    private getSelectedVacancies() {
        let selectedVacancyList: any[] = [];
        for (let item of this.selectedCandidatesOfVacancy) {
            selectedVacancyList = selectedVacancyList.concat({
                "candidateId": item.id,
                "vacancyId": this.id,
                "vacancyStage": item.vacancyStage
            })
        }
        return selectedVacancyList;
    }

    clearCandidateAttachVacancyForm() {
        this.candidateAttachVacancyForm.get('candidateId')!.setValue(null);
        this.candidateAttachVacancyForm.get('vacancyStage')!.setValue(null);
    }

    refreshVacancyStageCount() {
        let that = this;

        that.vacanciesDataService.getVacancyStagesCount(that.id).subscribe(
            data => {
                if (data) {
                    for (let statusCount of data) {
                        let { stage, count } = <{ stage: number, count: any }>statusCount;
                        that.vacancyStageCount[stage] = count;
                    }
                }
            }, error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, NotificationMessage.VACANCYSTAGESCOUNTLOADERROR);
            });
    }
}