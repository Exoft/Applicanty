using System.Linq;
using System.Linq.Dynamic.Core;

namespace Applicanty.API.Helpers
{
    public class GridRequest
    {
        public int? Take { get; set; }
        public int? Skip { get; set; }
        public string SortField { get; set; }
        public string SortDir { get; set; }

        public IQueryable<TEntity> Sort<TEntity>(IQueryable<TEntity> collection)
        {
            if (SortField != null)
               collection = collection.OrderBy($"{SortField } {SortDir}");

            if (Take != null && Skip != null)
                collection = collection.Skip(Skip.Value).Take(Take.Value);

            return collection;
        }
    }
}