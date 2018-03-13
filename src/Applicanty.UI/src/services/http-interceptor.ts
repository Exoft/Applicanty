import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpHandler, HttpRequest, HttpEvent } from '@angular/common/http';
import { AuthService } from '../services/auth.service';
import { NotificationService } from '../services/notification.service';
import { NotificationType } from '../enums/notification-type';
import { Router } from "@angular/router";

@Injectable()
export class AuthenticationInterceptor implements HttpInterceptor {

    constructor(private router: Router,
        private notificationService: NotificationService) {
    }

    private static badRequestErrorMessage: string = 'Bad Request';

    public static set setbadRequestErrorMessage(message: string) {
        AuthenticationInterceptor.badRequestErrorMessage = message;
    }

    intercept(req: HttpRequest<any>,
        next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).do(
            succ => { },
            err => {
                if (err.status === 401) {
                    this.notificationService.notify(NotificationType.Error, 'unauthorizedError');
                    setTimeout(() => {
                        localStorage.removeItem('accessToken');
                        this.router.navigate(['signin']);
                    }, 5000);
                } else if (err.status === 500) {
                    this.notificationService.notify(NotificationType.Error, 'internetServiceError');
                } else if (err.status === 404) {
                    this.router.navigate(['notfound']);
                } else if (err.status === 403) {
                    this.notificationService.notify(NotificationType.Error, 'forbiddenError');
                }
            }
        )
    }
}