import { Injectable, Component } from "@angular/core";

@Injectable()
export class ConstantaComponent {

    static DELETED: string = 'DELETED';
    static ARCHIVED: string = 'ARCHIVED';
    static ACTIVE: string = 'ACTIVE';

    constructor() {}    
}


