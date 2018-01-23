import { Component, ViewChild, OnInit, ElementRef } from '@angular/core';
import { ClarityIcons } from 'clarity-icons';

import { AuthService } from '../../../../services/auth.service';
import { NotificationService } from "../../../../services/notification.service";

import { NotificationComponent } from "../../../auth/components/notification/notification.component";
import { NotificationType } from "../../../../enums/notification-type";

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent {
    @ViewChild(NotificationComponent) set notificationComponent(notificationComponent: NotificationComponent) {
        if (notificationComponent) {
            this.notificationService.initialize(notificationComponent);
        }
    }

    constructor(public authService: AuthService,
        private notificationService: NotificationService) {
    }
    
    public logoutClick(e) {
        e.preventDefault();

        this.authService.signOut();
    }
}
