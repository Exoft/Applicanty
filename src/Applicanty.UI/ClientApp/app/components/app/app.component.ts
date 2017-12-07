import { Component, OnInit } from '@angular/core';
import { HttpService } from './http.service';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent/*implements OnInit */{
   /* user: User;
    constructor(private httpService: HttpService) { }

    ngOnInit() {

        this.httpService.getData().subscribe((data: User) => this.user = data);
    }*/
}
