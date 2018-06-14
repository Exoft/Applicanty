import { Component, EventEmitter, Input, OnInit } from '@angular/core';
import { Filter } from '@clr/angular';
import { GridFilterCreater } from '../grid-filter-creater';
import { GridFilterItem } from '../grid-filter-item';
import { FilterOperators } from '../../../constants/filter-opertors';

@Component({
    selector: 'apl-clr-datagrid-priority-filter',
    templateUrl: './priority-filter.html',
    styleUrls: ['./priority-filter.scss']
})
export class PriorityFilterComponent implements GridFilterCreater {
    @Input() priorities: any[] = [];
    @Input() propertyName = '';
    public filter: GridFilterItem | null = null;

    private selectedPriorities: { [priorityId: number]: boolean } = {};
    private nbPriorities = 0;

    changes: EventEmitter<any> = new EventEmitter<any>(false);

    listSelected(): string {
        const list: string[] = [];
        for (const priority  in this.selectedPriorities) {
            if (this.selectedPriorities[priority ]) {
                list.push(priority );
            }
        }
        return list.toString();
    }

    togglePriority(priorityId: number) {
        this.selectedPriorities[priorityId] = !this.selectedPriorities[priorityId];
        this.selectedPriorities[priorityId] ? this.nbPriorities++ : this.nbPriorities--;
        this.filter = this.createGridFilterItem();
        this.changes.emit(this.filter);
    }

    accepts(item: any) {
        return this.nbPriorities === 0 || this.selectedPriorities[item];
    }

    isActive(): boolean {
        return this.nbPriorities > 0;
    }

    createGridFilterItem(): GridFilterItem {
        return { field: this.propertyName, operator: FilterOperators.CONTAINSARRAY, value: this.listSelected() };
    }
}
