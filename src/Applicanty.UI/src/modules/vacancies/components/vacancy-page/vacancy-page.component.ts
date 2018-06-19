import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { Subscription } from 'rxjs/Subscription';
import { Observable } from 'rxjs/Observable';

import { VacanciesDataService } from '../../services/vacancies-data.service';
import { EnumDataService } from '../../../../services/enum.data.service';

import { EnumNames } from '../../../../constants/enum-names';

import { ValidationService } from '../../../../services/validation.service';
import { NotificationService } from '../../../../services/notification.service';
import { NotificationType } from '../../../../enums/notification-type';
import 'rxjs/add/observable/forkJoin';

@Component({
    templateUrl: './vacancy-page.component.html',
    styleUrls: ['./vacancy-page.component.scss']
})
export class VacancyPageComponent implements OnInit, OnDestroy {
    public setStageModalVisible = false;
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
    public comments: {
        text: String,
        createdAt: Date,
        createdBy: String
    }[] = [];

    public potentialCandidateGridLoading = true;
    public gridLoading = true;

    public froalaOptions: Object = {
        charCounterCount: true,
        toolbarButtons: ['bold', 'italic', 'underline', '|', 'fontFamily', 'fontSize', '|', 'align', 'formatOL',
            'formatUL', '|', 'selectAll', 'clearFormatting', '|', 'undo', 'redo'],
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
        'jobDescription': new FormControl('', [Validators.required, Validators.minLength(20)]),
        'commentText': new FormControl('')
    });


    public candidateAttachVacancyForm: FormGroup = new FormGroup({
        'candidateId': new FormControl('', Validators.required),
        'vacancyStage': new FormControl('', Validators.required)
    });


    constructor(private vacanciesDataService: VacanciesDataService,
        private enumService: EnumDataService,
        private activeRoute: ActivatedRoute,
        private router: Router,
        public validationService: ValidationService,
        private notificationService: NotificationService) {

        this.subscription = activeRoute.params.subscribe(params => this.id = params['id']);
    }

    ngOnInit() {
        if (this.id) {
            this.vacanciesDataService.getVacancy(this.id).subscribe(
                vacancy => {
                    if (vacancy) {
                        this.setFormData(vacancy);
                        this.refreshPotentialCandidates();
                    }
                }, error => {
                    if (error.status === 400) {
                        this.notificationService.notify(NotificationType.Error, 'vacancyDetailsLoadError');
                    }
                });

            this.enumService.getEnums(this.stageEnum).subscribe(
                data => {
                    this.vacancyStages = data.result;
                }, error => {
                    if (error.status === 400) {
                        this.notificationService.notify(NotificationType.Error, 'vacancyStageLoadError');
                    }
                });

            this.refreshVacancyStageCount();
        }

        this.vacanciesDataService.getTechnologies().subscribe(
            data => {
                this.technologies = data;
            }, error => {
                if (error.status === 400) {
                    this.notificationService.notify(NotificationType.Error, 'technologiesLoadError');
                }
            });

        this.enumService.getEnums(this.experienceEnum).subscribe(
            data => {
                this.experiences = data.result;
            }, error => {
                if (error.status === 400) {
                    this.notificationService.notify(NotificationType.Error, 'experienceLoadError');
                }
            });
        this.enumService.getEnums(this.priorityEnum).subscribe(
            data => {
                this.priorities = data.result;
            }, error => {
                if (error.status === 400) {
                    this.notificationService.notify(NotificationType.Error, 'priorityLoadError');
                }
            });
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }

    private setFormData(vacancy) {
        const createDate = new Date(vacancy.createdAt);
        this.vacancyPageForm.setValue({
            'id': vacancy.id,
            'title': vacancy.title,
            'createdBy': Number(vacancy.createdBy),
            'createdAt': createDate.getFullYear() + '-' + ((createDate.getMonth() + 1).toString().length === 1 ? '0'
                + (createDate.getMonth() + 1).toString() : (createDate.getMonth() + 1).toString()) + '-'
                + (createDate.getDate().toString().length === 1 ? '0' + createDate.getDate().toString() : createDate.getDate()),
            'technologyIds': vacancy.technologyIds,
            'experienceId': vacancy.experienceId,
            'priorityId': vacancy.priorityId,
            'vacancyDescription': vacancy.vacancyDescription,
            'jobDescription': vacancy.jobDescription,
            'commentText': null
        });

        const commentsCount = vacancy.commentText.length;
        for (let i = 0; i < commentsCount; i++) {
            this.comments.push({
                text: vacancy.commentText[i].replace(/(<p>|<\/p>)/, ''),
                createdAt: vacancy.commentCreatedAt[i],
                createdBy: vacancy.commentCreatedBy[i]
            });
        }
    }

    public saveVacancyClick(event) {
        const formData = this.vacancyPageForm.value;
        if (!this.id) {
            formData['id'] = 0;

            this.vacanciesDataService.createVacancy(formData).subscribe(
                data => {
                    this.router.navigate(['../vacancies']);
                },
                error => {
                    if (error.status === 400) {
                        this.notificationService.notify(NotificationType.Error, 'createVacancyError');
                    }
                });
        } else {
            this.vacanciesDataService.updateVacancy(formData).subscribe(
                data => {
                    this.router.navigate(['../vacancies']);
                },
                error => {
                    if (error.status === 400) {
                        this.notificationService.notify(NotificationType.Error, 'updateVacancyError');
                    }
                });
        }
    }

    public cancelClick(event) {
        this.router.navigate(['../vacancies']);
        this.candidateByTechnologyAndExperience = [];
    }

    public vacancyTechnologiesChange(event) {
        const id = Number(event.target.value);

        const selectedTechnologies = this.vacancyPageForm.get('technologyIds').value;

        if (event.target.checked) {
            if (selectedTechnologies.indexOf(id) < 0) {
                selectedTechnologies.push(id);
            }
        } else {
            if (selectedTechnologies.indexOf(id) >= 0) {
                selectedTechnologies.splice(selectedTechnologies.indexOf(id), 1);
            }
        }

        this.vacancyPageForm.get('technologyIds').setValue(selectedTechnologies);

        this.vacancyPageForm.get('technologyIds').markAsDirty();
        this.vacancyPageForm.get('technologyIds').markAsTouched();

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
        this.candidateByTechnologyAndExperience = [];
        const formData = this.vacancyPageForm.value;

        const technologyIds = this.vacancyPageForm.get('technologyIds').value;
        const experienceId = this.vacancyPageForm.get('experienceId').value;

        Observable.forkJoin(
            this.vacanciesDataService.getCandidateByVacancy(this.id),
            this.vacanciesDataService.getCandidateByTechnologyAndExperience(experienceId, technologyIds))
            .subscribe(
                data => {
                    this.addedCandidates = data[0].result;
                    this.availableCandidatesForSelection = data[1];
                    const idArray = this.addedCandidates.filter(function (el, index, array) {
                        return el.id;
                    });
                    for (let i = 0; i < this.availableCandidatesForSelection.length; i++) {
                        if (!idArray.some(item => item.id === this.availableCandidatesForSelection[i].id)) {
                            this.candidateByTechnologyAndExperience.push(this.availableCandidatesForSelection[i]);
                        }
                    }
                    this.setStageModalVisible = true;
                });

        this.vacanciesDataService.updateVacancy(formData).subscribe(
            data => {
            });
    }

    public attachToCandidateClick(event) {
        const formData = this.candidateAttachVacancyForm.value;
        this.vacanciesDataService.attachVacancyToCandidateStage({
            'vacancyId': this.id,
            'candidateId': Number(formData.candidateId),
            'vacancyStage': Number(formData.vacancyStage)
        }).subscribe(
            data => {
                this.refreshCurrentVacancyList();
                this.setStageModalVisible = false;
                this.refreshVacancyStageCount();
                this.refreshPotentialCandidates();
            });
    }

    public deleteCandydateClick(event) {
        if (this.getSelectedVacancies()) {
            const arr = this.getSelectedVacancies();
            for (const item of arr) {
                this.vacanciesDataService.detachCandidate(item).subscribe(
                    data => {
                        this.refreshCurrentVacancyList();
                    });
            }
        }
        this.refreshPotentialCandidates();
    }

    private refreshCurrentVacancyList() {
        this.gridLoading = true;

        this.vacanciesDataService.getCandidateByVacancy(this.id).subscribe(
            data => {
                this.gridLoading = false;
                this.candidatesByVacancy = data.result;
            },
            error => {
                if (error.status === 400) {
                    this.notificationService.notify(NotificationType.Error, 'candidatesListLoadError');
                }
            });

        this.selectedCandidatesOfVacancy = [];
        this.clearCandidateAttachVacancyForm();
        this.refreshVacancyStageCount();
    }

    private getSelectedVacancies() {
        let selectedVacancyList: any[] = [];
        for (const item of this.selectedCandidatesOfVacancy) {
            selectedVacancyList = selectedVacancyList.concat({
                'candidateId': item.id,
                'vacancyId': this.id,
                'vacancyStage': item.vacancyStage
            });
        }
        return selectedVacancyList;
    }

    clearCandidateAttachVacancyForm() {
        this.candidateAttachVacancyForm.get('candidateId').setValue(null);
        this.candidateAttachVacancyForm.get('vacancyStage').setValue(null);
    }

    refreshVacancyStageCount() {
        this.vacanciesDataService.getVacancyStagesCount(this.id).subscribe(
            data => {
                if (data) {
                    for (const statusCount of data) {
                        const { stage, count } = <{ stage: number, count: any }>statusCount;
                        this.vacancyStageCount[stage] = count;
                    }
                }
            },
            error => {
                if (error.status === 400) {
                    this.notificationService.notify(NotificationType.Error, 'vacancyStagesCountLoadError');
                }
            });
    }

    refreshPotentialCandidates() {
        this.candidateByTechnologyAndExperience = [];
        const formData = this.vacancyPageForm.value;
        this.potentialCandidateGridLoading = true;

        const technologyIds = this.vacancyPageForm.get('technologyIds').value;
        const experienceId = this.vacancyPageForm.get('experienceId').value;
        this.vacanciesDataService.getCandidateByVacancy(this.id),

            Observable.forkJoin(
                this.vacanciesDataService.getCandidateByVacancy(this.id),
                this.vacanciesDataService
                    .getCandidateByTechnologyAndExperience(experienceId, technologyIds))
                .subscribe(data => {
                    this.potentialCandidateGridLoading = false;
                    this.addedCandidates = data[0].result;
                    this.availableCandidatesForSelection = data[1];

                    const idArray = this.addedCandidates.filter((el, index, array) => {
                        return el.id;
                    });

                    this.availableCandidatesForSelection.forEach((el, index, arr) => {
                        if (!idArray.some(item => item.id === el.id)) {
                            this.candidateByTechnologyAndExperience.push(el);
                        }
                    });
                },
                    error => {
                        this.potentialCandidateGridLoading = false;

                        if (error.status === 400) {
                            this.notificationService.notify(NotificationType.Error, 'potentialCandidatesLoadError');
                        }
                    });
    }
}
