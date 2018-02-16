import { GridFilterItem } from "./grid-filter-item";

export interface GridFilterCreater {
    CreateGridFilterItem(item: GridFilterItem): GridFilterItem;
}