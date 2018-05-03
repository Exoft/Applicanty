import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { Subscription } from 'rxjs/Subscription';
import { Observable } from "rxjs/Observable";

import { VacanciesDataService } from '../../services/vacancies-data.service';
import { EnumDataService } from '../../../../services/enum.data.service';

import { EnumNames } from '../../../../constants/enum-names';

import { ValidationService } from "../../../../services/validation.service";
import { NotificationService } from "../../../../services/notification.service";
import { NotificationType } from "../../../../enums/notification-type";
import 'rxjs/add/observable/forkJoin';

@Component({
    templateUrl: './vacancy-page.component.html',
    styleUrls: ['./vacancy-page.component.scss']
})
export class VacancyPageComponent implements OnInit, OnDestroy {
    public setStageModalVisible: boolean = false;
    public id;
    private subscription: Subscription = new Subscription();

    public technologies: any[] = [];
    public experiences: any[] = [];
    public priorities: any[] = [];
    public vacancyStages: any[] = [];
    public selectedCandidatesOfVacancy: any[] = [];
    public vacancyStageCount: { [value: number]: any } = {};
    public candidatesByVacancy: any[] = [];
    public candidateByTechnologyAndExperience: any[] = [];
    public addedCandidates: any[] = [];
    public availableCandidatesForSelection: any[] = [];
    public potentialCandidateList: any[] = [];

    public potentialCandidateGridLoading: boolean = false;
    public gridLoading: boolean = false;

    public froalaOptions: Object = {
        charCounterCount: true,
        toolbarButtons: ['bold', 'italic', 'underline', '|', 'fontFamily', 'fontSize', '|', 'align', 'formatOL', 'formatUL', '|', 'selectAll', 'clearFormatting', '|', 'undo', 'redo'],
        toolbarButtonsXS: ['bold', 'italic', 'underline', '|', 'fontFamily', 'fontSize', '|', 'align', '|', 'undo', 'redo'],
        toolbarButtonsSM: ['bold', 'italic', 'underline', '|', 'fontFamily', 'fontSize', '|', 'align', '|', 'undo', 'redo'],
        toolbarButtonsMD: ['bold', 'italic', 'underline', '|', 'fontFamily', 'fontSize', '|', 'align', '|', 'undo', 'redo'],
    };

    private experienceEnum = EnumNames.EXPERIENCE;
    private priorityEnum = EnumNames.PRIORITY;
    private stageEnum = EnumNames.VACANCYSTAGE;

    public vacancyPageForm: FormGroup = new FormGroup({
        'id': new FormControl(''),
        'title': new FormControl('', Validators.required),
        'createdBy': new FormControl(''),
        'createdAt': new FormControl(new Date().toLocaleDateString()),
        'technologyIds': new FormControl([]),
        'experienceId': new FormControl(0, Validators.required),
        'priorityId': new FormControl(0, Validators.required),
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
                        that.refreshPotentialCandidates();
                    }
                }, error => {
                    if (error.status == 400)
                        that.notificationService.notify(NotificationType.Error, 'vacancyDetailsLoadError');
                });

            that.enumService.getEnums(that.stageEnum).subscribe(
                data => {
                    that.vacancyStages = data.result;
                }, error => {
                    if (error.status == 400)
                        that.notificationService.notify(NotificationType.Error, 'vacancyStageLoadError');
                });

            that.refreshVacancyStageCount();
        }

        that.vacanciesDataService.getTechnologies().subscribe(
            data => {
                that.technologies = data;
            }, error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, 'technologiesLoadError');
            });

        that.enumService.getEnums(that.experienceEnum).subscribe(
            data => {
                that.experiences = data.result;
            }, error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, 'experienceLoadError');
            });
            that.enumService.getEnums(that.priorityEnum).subscribe(
                data => {
                    that.priorities = data.result;
                }, error => {
                    if (error.status == 400)
                        that.notificationService.notify(NotificationType.Error, 'priorityLoadError');
                });  
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }

    private setFormData(vacancy) {
        var createDate = new Date(vacancy.createdAt);
        this.vacancyPageForm.setValue({
            'id': vacancy.id,
            'title': vacancy.title,
            'createdBy': Number(vacancy.createdBy),
            'createdAt': createDate.getFullYear() + '-' + ((createDate.getMonth() + 1).toString().length === 1 ? '0' + (createDate.getMonth() + 1).toString() : (createDate.getMonth() + 1).toString()) + '-' + (createDate.getDate().toString().length === 1 ? '0' + createDate.getDate().toString() : createDate.getDate()),
            'technologyIds': vacancy.technologyIds,
            'experienceId': vacancy.experienceId,
            'priorityId': vacancy.priorityId,
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
                        that.notificationService.notify(NotificationType.Error, 'createVacancyError');
                });
        } else {
            that.vacanciesDataService.updateVacancy(formData).subscribe(
                data => {
                    that.router.navigate(['../vacancies']);
                },
                error => {
                    if (error.status == 400)
                        that.notificationService.notify(NotificationType.Error, 'updateVacancyError');
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

        this.refreshPotentialCandidates();
    }

    public vacancyStageLabelClick(event: Event, idStage: number) {
        event.preventDefault();

        if (this.vacancyStageCount[idStage]) {
            this.router.navigate(['../', 'candidates', 'vacancy', this.id, 'stage', idStage]);
        }
    }

    public showAvailableCandidates(event) {
        let that = this;
        that.candidateByTechnologyAndExperience = [];
        let formData = that.vacancyPageForm.value;

        let technologyIds = that.vacancyPageForm.get('technologyIds')!.value;
        let experienceId = that.vacancyPageForm.get('experienceId')!.value;

        Observable.forkJoin(
            that.vacanciesDataService.getCandidateByVacancy(that.id),
            that.vacanciesDataService.getCandidateByTechnologyAndExperience(experienceId, technologyIds))
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
                that.refreshPotentialCandidates();
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
        that.refreshPotentialCandidates();
    }

    private refreshCurrentVacancyList() {
        let that = this;

        that.gridLoading = true;

        that.vacanciesDataService.getCandidateByVacancy(that.id).subscribe(
            data => {
                that.gridLoading = false;
                that.candidatesByVacancy = data.result;
            },
            error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, 'candidatesListLoadError');
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
            },
            error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, 'vacancyStagesCountLoadError');
            });
    }

    refreshPotentialCandidates() {
        this.candidateByTechnologyAndExperience = [];
        let formData = this.vacancyPageForm.value;
        this.potentialCandidateGridLoading = true;

        let technologyIds = this.vacancyPageForm.get('technologyIds')!.value;
        let experienceId = this.vacancyPageForm.get('experienceId')!.value;
        this.vacanciesDataService.getCandidateByVacancy(this.id),

            Observable.forkJoin(
                this.vacanciesDataService.getCandidateByVacancy(this.id),
                this.vacanciesDataService
                    .getCandidateByTechnologyAndExperience(experienceId, technologyIds))
                    .subscribe( data => {
                        this.potentialCandidateGridLoading = false;
                        this.addedCandidates = data[0].result;
                        this.availableCandidatesForSelection = data[1];

                        let idArray = this.addedCandidates.filter((el, index, array) => {
                            return el.id;
                        });

                        this.availableCandidatesForSelection.forEach((el, index, arr) => {
                            if (!idArray.some(item => item.id === el.id)) {
                                this.candidateByTechnologyAndExperience.push(el);
                            }
                        })
                    },
                    error => {
                        this.potentialCandidateGridLoading = false;

                        if (error.status == 400)
                            this.notificationService.notify(NotificationType.Error, 'potentialCandidatesLoadError');
                    });
    }
}
