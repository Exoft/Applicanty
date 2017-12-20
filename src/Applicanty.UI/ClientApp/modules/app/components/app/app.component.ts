import { Component } from '@angular/core';
import { ClarityIcons } from 'clarity-icons';

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

        this.authService.signOut();
    }
}
