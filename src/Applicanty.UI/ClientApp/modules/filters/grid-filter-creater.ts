import { GridFilterItem } from "./grid-filter-item";

export interface GridFilterCreater {
    propertyName: string;
    filter: GridFilterItem | GridFilterItem[] | null;
    CreateGridFilterItem(): GridFilterItem | GridFilterItem[];
}