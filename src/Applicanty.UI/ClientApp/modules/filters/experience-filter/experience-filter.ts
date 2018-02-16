import { Component, EventEmitter, Input, OnInit } from "@angular/core";
import { Filter } from "clarity-angular";
import { EnumDataService } from "../../../services/enum.data.service";
import { NotificationService } from "../../../services/notification.service";
import { EnumNames } from "../../../constants/enum-names";
import { NotificationType } from "../../../enums/notification-type";
import { NotificationMessage } from "../../../constants/notification-message";

@Component({
    selector: 'clr-datagrid-experience-filter',
    templateUrl: './experience-filter.html',
    providers: [EnumDataService],
    styleUrls: ['./experience-filter.scss']
})
export class ExperienceFilter implements Filter<any>, OnInit {
    //@Input() experience: { value: number, name: string };
    selectedExperiences: { [experience: string]: boolean } = {};
    nbExperiences: number = 0;
    private allExperiences: any[] = [];

    changes: EventEmitter<any> = new EventEmitter<any>(false);

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

    listSelected(): string[] {
        const list: string[] = [];
        for (const experience in this.selectedExperiences) {
            if (this.selectedExperiences[experience]) {
                list.push(experience);
            }
        }
        return list;
    }

    toggleExperience(experience: string) {
        this.selectedExperiences[experience] = !this.selectedExperiences[experience];
        this.selectedExperiences[experience] ? this.nbExperiences++ : this.nbExperiences--;
        this.changes.emit(this.listSelected());
    }

    accepts(item: any) {
        return this.nbExperiences === 0 || this.selectedExperiences[item];
    }

    isActive(): boolean {
        return this.nbExperiences > 0;
    }

}