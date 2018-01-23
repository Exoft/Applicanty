import { Injectable } from '@angular/core';

import { NotificationType } from '../enums/notification-type';

import { NotificationComponent } from "../modules/auth/components/notification/notification.component";

@Injectable()
export class NotificationService {

    private notificationComponent: NotificationComponent;

    public initialize(notificationComponent: NotificationComponent) {
        if (!this.notificationComponent) {
            this.notificationComponent = notificationComponent;
        }
    }
    
    public notify(notificationType: NotificationType, message: string) {
        if (this.notificationComponent) {
            this.notificationComponent.show(notificationType, message);
        }
    }
}