import { GridFilterItem } from '../modules/filters/grid-filter-item';

export interface GridRequest {
    take: number;
    skip: number;
    sortField?: string;
    sortDir?: string;
    filters?: GridFilterItem[];
}
