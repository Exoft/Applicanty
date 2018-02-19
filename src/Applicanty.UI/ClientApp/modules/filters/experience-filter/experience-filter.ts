﻿import { Component, EventEmitter, Input, OnInit } from "@angular/core";
import { Filter } from "clarity-angular";
import { EnumDataService } from "../../../services/enum.data.service";
import { NotificationService } from "../../../services/notification.service";
import { EnumNames } from "../../../constants/enum-names";
import { NotificationType } from "../../../enums/notification-type";
import { NotificationMessage } from "../../../constants/notification-message";
import { GridFilterCreater } from "../grid-filter-creater";
import { GridFilterItem } from "../grid-filter-item";
import { FilterOperators } from "../../../constants/filter-opertors";

@Component({
    selector: 'clr-datagrid-experience-filter',
    templateUrl: './experience-filter.html',
    providers: [EnumDataService],
    styleUrls: ['./experience-filter.scss']
})
export class ExperienceFilter implements Filter<any>, GridFilterCreater, OnInit {
    //@Input() experience: { value: number, name: string };
    @Input() propertyName: string;
    public filter: GridFilterItem;

    private selectedExperiences: { [experienceId: number]: boolean } = {};
    private nbExperiences: number = 0;

    changes: EventEmitter<any> = new EventEmitter<any>(false);

    private allExperiences: any[] = [];

    constructor(private enumService: EnumDataService,
        private notificationService: NotificationService) { }

    ngOnInit() {
        let that = this;
        that.enumService.getEnums(EnumNames.EXPERIENCE).subscribe(
            data => {
                that.allExperiences = data.result;
            }, error => {
                if (error.status == 400)
                    that.notificationService.notify(NotificationType.Error, NotificationMessage.EXPERIENCELOADERROR);
            });
    }

    listSelected(): string {
        let list: string[] = [];
        for (let experience in this.selectedExperiences) {
            if (this.selectedExperiences[experience]) {
                list.push(experience);
            }
        }
        return list.toString();
    }

    toggleExperience(experienceId: number) {
        this.selectedExperiences[experienceId] = !this.selectedExperiences[experienceId];
        this.selectedExperiences[experienceId] ? this.nbExperiences++ : this.nbExperiences--;
        this.filter = this.CreateGridFilterItem();
        this.changes.emit(this.filter);
    }

    accepts(item: any) {
        return this.nbExperiences === 0 || this.selectedExperiences[item];
    }

    isActive(): boolean {
        return this.nbExperiences > 0;
    }

    CreateGridFilterItem(): GridFilterItem {
        return { field: this.propertyName, operator: FilterOperators.CONTAINSARRAY, value: this.listSelected() };
    }
}