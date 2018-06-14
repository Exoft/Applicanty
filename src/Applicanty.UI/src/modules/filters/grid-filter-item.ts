import { FilterOperators } from '../../constants/filter-opertors';

export interface GridFilterItem {
    readonly field: string;
    readonly value: string;
    readonly operator: FilterOperators;
}
