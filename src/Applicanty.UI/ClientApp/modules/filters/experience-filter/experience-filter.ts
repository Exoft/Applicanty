import { Component, EventEmitter, Input, OnInit } from "@angular/core";
import { Filter } from "clarity-angular";
import { GridFilterCreater } from "../grid-filter-creater";
import { GridFilterItem } from "../grid-filter-item";
import { FilterOperators } from "../../../constants/filter-opertors";

@Component({
    selector: 'clr-datagrid-experience-filter',
    templateUrl: './experience-filter.html',
    styleUrls: ['./experience-filter.scss']
})

export class ExperienceFilter implements Filter<any>, GridFilterCreater {
    @Input() experiences: any[] = [];
    @Input() propertyName: string = '';
    public filter: GridFilterItem | null = null;

    private selectedExperiences: { [experienceId: number]: boolean } = {};
    private nbExperiences: number = 0;

    changes: EventEmitter<any> = new EventEmitter<any>(false);

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