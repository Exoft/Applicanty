using Applicanty.Core.Entities;
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

        public IQueryable<TEntity> Request<TEntity>(IQueryable<TEntity> collection)
        {
            ApplySorting(ref collection);
            ApplyFiltering(ref collection);

            return collection;
        }

        private void ApplySorting<TEntity>(ref IQueryable<TEntity> collection)
        {
            if (SortField != null)
                collection = collection.OrderBy($"{SortField } {SortDir}");

            if (Take != null && Skip != null)
                collection = collection.Skip(Skip.Value).Take(Take.Value);

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
                           $" || {BuildWhereClause<TEntity>(i, Filters[i], parameters)}";
                }
                collection = collection.Where(whereClause, parameters.ToArray());
            }
        }

        private static string BuildWhereClause<TEntity>(int index, FilterItem filter,
            List<object> parameters)
        {
            var entityType = (typeof(TEntity));
            var property = entityType.GetProperty(filter.Field);

            switch (filter.Operator.ToLower())
            {
                case "eq":
                case "gte":
                case "lte":
                    if (typeof(DateTime).IsAssignableFrom(property.PropertyType))
                    {
                        parameters.Add(DateTime.Parse(filter.Value).Date);
                        return string.Format("EntityFunctions.TruncateTime({0}){1}@{2}",
                            filter.Field,
                            ToLinqOperator(filter.Operator),
                            index);
                    }
                    if (typeof(int).IsAssignableFrom(property.PropertyType))
                    {
                        parameters.Add(int.Parse(filter.Value));
                        return string.Format("{0}{1}@{2}",
                            filter.Field,
                            ToLinqOperator(filter.Operator),
                            index);
                    }
                    if (typeof(decimal).IsAssignableFrom(property.PropertyType))
                    {
                        parameters.Add(int.Parse(filter.Value));
                        return string.Format("{0}{1}@{2}",
                            filter.Field,
                            ToLinqOperator(filter.Operator),
                            index);
                    }
                    if (typeof(bool).IsAssignableFrom(property.PropertyType))
                    {
                        parameters.Add(bool.Parse(filter.Value));
                        return string.Format("{0}{1}@{2}",
                            filter.Field,
                            ToLinqOperator(filter.Operator),
                            index);
                    }
                    if (typeof(string).IsAssignableFrom(property.PropertyType))
                    {
                        parameters.Add(filter.Value.ToString());
                        return string.Format("{0}{1}@{2}",
                            filter.Field,
                            ToLinqOperator(filter.Operator),
                            index);
                    }
                    if (typeof(bool).IsAssignableFrom(property.PropertyType))
                    {
                        parameters.Add(bool.Parse(filter.Value));
                        return string.Format("{0}{1}@{2}",
                            filter.Field,
                            ToLinqOperator(filter.Operator),
                            index);
                    }
                    if (typeof(Enum).IsAssignableFrom(property.PropertyType))
                    {
                        int number;
                        if (Int32.TryParse(filter.Value, out number))
                        {
                            parameters.Add(Enum.ToObject(property.PropertyType, int.Parse(filter.Value)));
                        }
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
                case "eq":
                    return " == ";
                case "neq":
                    return " != ";
                case "gte":
                    return " >= ";
                case "gt":
                    return " > ";
                case "lte":
                    return " <= ";
                case "lt":
                    return " < ";
                case "or":
                    return " || ";
                case "and":
                    return " && "; // &amp;&amp; todo
                default:
                    return null;
            }
        }
    }
}