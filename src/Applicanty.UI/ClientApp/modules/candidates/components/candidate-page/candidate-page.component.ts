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
import { NotificationMassage } from "../../../../constants/notification-message";

@Component({
    templateUrl: './candidate-page.component.html',
    styleUrls: ['./candidate-page.component.scss']
})
export class CandidatePageComponent implements OnInit, OnDestroy {
    private id: number;
    private subscription: Subscription;

    private experienceEnum = EnumNames.EXPERIENCE;
    private stageEnum = EnumNames.VACANCYSTAGE;

    public experienсes: any[] = [];
    public technologies: any[] = [];

    public candidatePageFrom: FormGroup = new FormGroup({
        'id': new FormControl(''),
        'experienceId': new FormControl(0, Validators.required),
        'firstName': new FormControl('', Validators.required),
        'lastName': new FormControl('', Validators.required),
        'email': new FormControl('', Validators.required),
        'skype': new FormControl('', Validators.required),
        'linkedIn': new FormControl(''),
        'phone': new FormControl(''),
        'cvPath': new FormControl(''),
        'birthday': new FormControl(new Date(), Validators.required)
    });

    constructor(private candidatesDataService: CandidatesDataService,
        private enumService: EnumDataService,
        private activeRoute: ActivatedRoute,
        public validationService: ValidationService,
        private router: Router,
        private notificationService: NotificationService) {
        let that = this;

        that.subscription = activeRoute.params.subscribe(params => that.id = params['id']);
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
                        that.notificationService.notify(NotificationType.Error, NotificationMassage.CANDIDATEDETAILSLOADERROR);
                });

            that.enumService.getEnums(that.experienceEnum).subscribe(
                data => {
                    that.experienсes = data.result;
                },
                error => {
                    if (error.status == 400)
                        that.notificationService.notify(NotificationType.Error, NotificationMassage.CANDIDATESSTAGELOADERROR);
                });
        };

        that.candidatesDataService.getTechnologies().subscribe(
            data => {
                that.technologies = data;
            }, error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, NotificationMassage.TECHNOLOGIESLOADERROR);
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
            'email': candidate.email,
            'skype': candidate.skype,
            'linkedIn': candidate.linkedIn,
            'phone': candidate.phone,
            'cvPath': candidate.cvPath,
            'birthday': birthdayDate.getFullYear() + '-' + ((birthdayDate.getMonth() + 1).toString().length === 1 ? '0' + (birthdayDate.getMonth() + 1).toString() : (birthdayDate.getMonth() + 1).toString()) + '-' + (birthdayDate.getDate().toString().length === 1 ? '0' + birthdayDate.getDate().toString() : birthdayDate.getDate())
        });
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
                        that.notificationService.notify(NotificationType.Error, NotificationMassage.CREATECANDIDATEERROR);
                });
        } else {
            that.candidatesDataService.updateCandidate(formData).subscribe(
                data => {
                    that.router.navigate(['../candidates']);
                },
                error => {
                    if (error.status == 400)
                        that.notificationService.notify(NotificationType.Error, NotificationMassage.CANDIDATECHANGESTATUSERROR);
                });
        }
    }

    public cancelClick(event) {
        this.router.navigate(['../candidates']);
    }
}