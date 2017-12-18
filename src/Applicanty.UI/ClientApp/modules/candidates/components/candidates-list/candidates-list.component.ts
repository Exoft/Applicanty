import { Component, OnInit } from '@angular/core';
import { CandidatesDataService } from '../../services/candidates-data.service';

@Component({
    templateUrl: './candidates-list.component.html',
    styleUrls: ['./candidates-list.component.scss']
})
export class CandidatesListComponent implements OnInit {
    candidates = [];

    constructor(private сandidatesDataService: CandidatesDataService) { }
    ngOnInit() {
        this.сandidatesDataService.getCandidates().subscribe(data => this.candidates = data);
    }
    //candidates: any[] = [
    //    {
    //        name: 'Ivan',
    //        experienceLevel: 'Jun',
    //        lastVacancy: 'ASP.NET',
    //        email: 'Ivan@gmail.com',
    //        linkedIn: 'In',
    //        phone: '+49 75 6778 5643',
    //        age: 20
    //    },
    //    {
    //        name: 'Taras',
    //        experienceLevel: 'Midl',
    //        lastVacancy: 'Frontend Engineer',
    //        email: 'Taras@gmail.com',
    //        linkedIn: 'In',
    //        phone: '+49 56 6797 4576',
    //        age: 21
    //    },
    //    {
    //        name: 'Mikhaylo',
    //        experienceLevel: 'Sin',
    //        lastVacancy: 'Front-end',
    //        email: 'Mikhaylo@gmail.com',
    //        linkedIn: 'In',
    //        phone: '+49 67 4578 5467',
    //        age: 22
    //    },
    //    {
    //        name: 'Bogdan',
    //        experienceLevel: 'Jun',
    //        lastVacancy: 'Web UI Software Engineer',
    //        email: 'Bogdan@gmail.com',
    //        linkedIn: 'In',
    //        phone: '+49 96 6580 5469',
    //        age: 23
    //    },
    //    {
    //        name: 'Igor',
    //        experienceLevel: 'Midl',
    //        lastVacancy: 'Full Stack',
    //        email: 'Igor@gmail.com',
    //        linkedIn: 'In',
    //        phone: '+49 09 8478 8934',
    //        age: 24
    //    }
    //];
}