import { GridFilterItem } from "./grid-filter-item";

export interface GridFilterCreater {
    propertyName: string;
    filter: GridFilterItem | GridFilterItem[] | null;
    createGridFilterItem(): GridFilterItem | GridFilterItem[];
}