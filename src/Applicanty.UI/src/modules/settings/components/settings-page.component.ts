import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ValidationService } from '../../../services/validation.service';
import { SettingsDataService } from '../services/settings-data.services';

@Component({
    templateUrl: './settings-page.component.html',
    styleUrls: ['./settings-page.component.scss']
})
export class SettingsPageComponent implements OnInit {

    public setStageModalVisible = false;
    public technologies: any[] = [];


    constructor(private settingsDataService: SettingsDataService,
        private router: Router) {
    }

    public technologiesForm: FormGroup = new FormGroup({
        'technologies': new FormControl(),
        'technology': new FormControl(),
        'technologyIds': new FormControl(),
        'technologiesId': new FormControl()
    });

    public atachTechnologiesForm: FormGroup = new FormGroup({
        'name': new FormControl()
    });

    ngOnInit() {
        this.refreshTechnology();
    }

    public showModalTechnologies(event) {
        this.setStageModalVisible = true;
    }

    public vacancyTechnologiesChange(event) {
        const id = Number(event.target.value);
        console.log(id);
        return id;
        // let selectedTechnologies = this.technologiesForm.get('technologyIds')!.value;
        // console.log(selectedTechnologies);

        //    if (event.target.checked) {
        //        if (selectedTechnologies.indexOf(id) < 0) {
        //            selectedTechnologies.push(id);
        //        }
        //    } else {
        //        if (selectedTechnologies.indexOf(id) >= 0) {
        //            selectedTechnologies.splice(selectedTechnologies.indexOf(id), 1);
        //        }
        //    }

        //    this.candidatePageFrom.get('technologyIds')!.setValue(selectedTechnologies);

        //    this.candidatePageFrom.get('technologyIds')!.markAsDirty();
        //    this.candidatePageFrom.get('technologyIds')!.markAsTouched();

        //    this.candidatePageFrom.updateValueAndValidity();
        // }

    }



    public addTechnology(event) {
        const name: string = this.atachTechnologiesForm.value;
        this.settingsDataService.createNewTechnology(name).subscribe(
            data => {
                this.technologies = data;
                this.refreshTechnology();
                this.setStageModalVisible = false;
                this.clearAtachTechnologiesForm();
            }, );
    }

    public deleteTechnologies(event) {
        const id = this.vacancyTechnologiesChange(event);
        this.settingsDataService.deleteTechnology(id).subscribe(
            data => {
                this.technologies = data;
                console.log(data);
                this.refreshTechnology();
            });
    }

    public cancelClick(event) {
        this.router.navigate(['candidates']);
    }

    public refreshTechnology() {
        this.settingsDataService.getTechnologies().subscribe(
            data => {
                this.technologies = data;
            });
    }

    clearAtachTechnologiesForm() {
        this.atachTechnologiesForm.get('name').setValue(null);
    }

}
