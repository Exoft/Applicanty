import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'transformBirthDateToAge' })
export class TransformBirthDateToAgePipe implements PipeTransform {
    transform(value: string): number {
        var birthday = new Date(value);
        var today = new Date();
        var years = today.getFullYear() - birthday.getFullYear();

        birthday.setFullYear(today.getFullYear());

        if (today < birthday) {
            years--;
        }
        return years;
    }
}