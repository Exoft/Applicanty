import { Injectable, Inject } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { DecimalPipe } from '@angular/common';
//import { ConfigService } from "./config.service";

@Injectable()
export class ValidationService {
    private config = {};

    //public static productId: any;

    private static http: any;
    //private static appConfig: any;

    private static productNumberRegex = /^[0-9A-Z]{6}$/gm;

    constructor(private httpClient: HttpClient
        //,
        //@Inject('clientAppConfig') private clientAppConfig: any
    ) {
        ValidationService.http = httpClient;
        //ValidationService.appConfig = clientAppConfig;

        this.config = {
            'required': 'This field is required',
            //'shouldBeNumeric': 'Value should be numeric',
            'invalidProductNumber': 'Product number should match pattern [0-9A-Z]{6}',
            //'productNumberIsUsed': 'Product number is used by another product'
        };
    }

    public getValidatorErrorMessage(control: any) {
        if (control && control !== null) {
            for (let propertyName in control.errors) {
                if (control.errors.hasOwnProperty(propertyName)) {
                    return this.config[propertyName];
                }
            }
        }

        return null;
    }

    public getFormGroupValidatorErrorMessage(formGroup: any) {
        let errors: any[] = [];

        if (formGroup && formGroup !== null) {
            Object.keys(formGroup.controls).forEach(control => {
                let error = this.getValidatorErrorMessage(formGroup.get(control));

                if (error && error !== null) {
                    errors.push({ message: error, control: control });
                }
            });
        }

        if (errors.length) {
            return errors.map(item => `${item.control}: ${item.message}`).join('<br>');
        }

        return null;
    }

    //public isDoubleValidator(control: any) {
    //    if (!control.value) {
    //        return null;
    //    }
    //    debugger;

    //    let aaaaaa = parseFloat(control.value);

    //    let aaa = !isNaN(control.value - parseFloat(control.value.toLocaleString('en-US')));

    //    return null;

    //    let isValid = !isNaN(parseFloat(control.value)) && isFinite(control.value);
    //    if (isValid) {
    //        return null;
    //    } else {
    //        return { "shouldBeNumeric": true };
    //    }
    //}

    public productNumberPatternValidator(control) {
        if (!control.value || control.value === null)
            return null;

        if (control.value.match(ValidationService.productNumberRegex)) {
            return null;
        } else {
            return { 'invalidProductNumber': true };
        }
    }

    //public productNumberIsAvailableValidator(control): Promise<any> {
    //    let that = this;

    //    return new Promise(resolve => {
    //        ValidationService.http.get(`${ValidationService.appConfig['PRODUCTSERVICE_HOST']}products/product-number-available?productId=${ValidationService.productId}&productNumber=${control.value}`)
    //            .subscribe(result => {
    //                if (result['isAvailable']) {
    //                    resolve(null);
    //                } else {
    //                    resolve({ "productNumberIsUsed": true });
    //                }
    //            });
    //    });
    //    }
}
