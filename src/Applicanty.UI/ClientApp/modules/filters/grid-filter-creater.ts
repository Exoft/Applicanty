import { GridFilterItem } from "./grid-filter-item";

export interface GridFilterCreater {
    propertyName: string;
    filter: GridFilterItem | GridFilterItem[];
    CreateGridFilterItem(): GridFilterItem | GridFilterItem[];
}