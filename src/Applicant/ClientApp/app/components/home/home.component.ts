import { Component } from '@angular/core';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    myVar: any;

    ngOnInit() {
        let that = this;

        that.myVar = "Bodya";
    }
}
