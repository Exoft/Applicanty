using Applicanty.Core.Entities;
using Applicanty.Core.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Applicanty.API.Helpers
{
    public class GridHelper
    {
        public int? Take { get; set; }
        public int? Skip { get; set; }
        public string SortField { get; set; }
        public string SortDir { get; set; }
        public List<FilterItem> Filters { get; set; }

        public Response<TEntity> FilterAndSort<TEntity>(IQueryable<TEntity> collection)
        {
            ApplySorting(ref collection);
            ApplyFiltering(ref collection);

            var response = new Response<TEntity>
            {
                Result = collection.Skip(Skip.Value).Take(Take.Value),
                TotalCount = collection.Count()
            };

            return response;
        }

        private void ApplySorting<TEntity>(ref IQueryable<TEntity> collection)
        {
            if (SortField != null)
                collection = collection.OrderBy($"{SortField } {SortDir}");
        }

        private void ApplyFiltering<TEntity>(ref IQueryable<TEntity> collection)
        {
            if (Filters != null && Filters.Count > 0)
            {
                string whereClause = string.Empty; ;
                var parameters = new List<object>();

                for (int i = 0; i < Filters.Count; i++)
                {
                    if (i == 0)
                        whereClause +=
                            $"{BuildWhereClause<TEntity>(i, Filters[i], parameters)}";
                    else
                        whereClause +=
                           $" && {BuildWhereClause<TEntity>(i, Filters[i], parameters)}";
                }
                collection = collection.Where(whereClause, parameters.ToArray());
            }
        }

        private static string BuildWhereClause<TEntity>(int index, FilterItem filter, List<object> parameters)
        {
            var entityType = (typeof(TEntity));
            var property = entityType.GetProperty((UppercaseFirst(filter.Field)));

            switch (filter.Operator.ToLower())
            {
                case "gte":
                case "lte":
                    if (typeof(DateTime).IsAssignableFrom(property.PropertyType))
                    {
                        parameters.Add(DateTime.Parse(filter.Value).Date);
                        return string.Format("{0}{1}@{2}",
                            filter.Field,
                            ToLinqOperator(filter.Operator),
                            index);
                    }
                    parameters.Add(filter.Value);
                    return string.Format("{0}{1}@{2}",
                        filter.Field,
                        ToLinqOperator(filter.Operator),
                        index);
                case "contains":
                    parameters.Add(filter.Value);
                    return string.Format("{0}.Contains(@{1})",
                        filter.Field,
                        index);
                case "containsarray":
                    var a = filter.Value.Split(',').Select(h => Int32.Parse(h)).ToArray();
                    parameters.Add(a);
                    return string.Format("@{1}.Contains({0})",
                        filter.Field,
                        index);

                default:
                    throw new ArgumentException("This operator is not yet supported for this Grid", filter.Operator);
            }
        }

        private static string ToLinqOperator(string @operator)
        {
            switch (@operator.ToLower())
            {
                case "gte":
                    return " >= ";
                case "lte":
                    return " <= ";
                default:
                    return null;
            }
        }

        public static string UppercaseFirst(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            return char.ToUpper(str[0]) + str.Substring(1);
        }
    }
}