import { Component } from '@angular/core';

import { AuthService } from '../../../../services/auth.service';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent {

    constructor(public authService: AuthService) {
    }

    logoutClick(e) {
        e.preventDefault();

        this.authService.logout();
    }
}
