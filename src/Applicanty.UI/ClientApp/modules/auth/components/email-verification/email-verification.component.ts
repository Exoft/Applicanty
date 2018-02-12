import { Component, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from "@angular/router";

import { Subscription } from "rxjs/Subscription";

import { AuthService } from "../../../../services/auth.service";

@Component({
    templateUrl: './email-verification.component.html',
    styleUrls: ['./email-verification.component.scss']
})
export class EmailVerificationComponent implements OnDestroy {

    public email: any;
    public token: any;
    public confirmed = false;

    private countdown = 3;
    private subscription: Subscription = new Subscription();

    constructor(private authService: AuthService,
        private activeRoute: ActivatedRoute,
        private router: Router) {

        let that = this;

        that.subscription = activeRoute.queryParams.subscribe(params => {
            if (params.hasOwnProperty('email')) {
                that.email = params['email'];
            }

            if (params.hasOwnProperty('email') && params.hasOwnProperty('token')) {
                that.token = params['token'];

                that.authService.confirmEmail(params['email'], params['token']).subscribe(
                    data => {
                        that.confirmed = true;

                        setTimeout(that.countDown, 1000);
                    },
                    error => {
                    });
            }
        });
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }

    private countDown() {
        this.countdown--;

        if (this.countdown > 0) {
            setTimeout(this.countDown, 1000);
        } else {
            this.router.navigate(['signin']);
        }
    }
}