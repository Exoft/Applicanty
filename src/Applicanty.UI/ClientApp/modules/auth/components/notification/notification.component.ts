import { Component, OnInit } from '@angular/core';

import { NotificationService } from '../../../../services/notification.service';

import { NotificationType } from "../../../../enums/notification-type";

@Component({
    selector: 'notification-message',
    templateUrl: './notification.component.html',
    styleUrls: ['./notification.component.scss']
})
export class NotificationComponent {
    public message: string;
    public notificationType: NotificationType;

    public visible = false;

    public successNotificatioType = NotificationType.Success;
    public errorNotificatioType = NotificationType.Error;

    public show(notificationType: NotificationType, message: string) {
        let that = this;

        that.message = message;
        that.notificationType = notificationType;
        that.visible = true;

        setTimeout(() => {
            that.visible = false;
        }, 5000);
    }
}