using System.Collections.Generic;
using System.Linq;

namespace Applicanty.API.Helpers
{
    public class ListHelper<TDto> where TDto : class
    {
        public static IEnumerable<TDto> SortBy(IEnumerable<TDto> list, string property, string sortBy)
        {
            if (!string.IsNullOrEmpty(property))
            {
                list = list.OrderBy(o => o.GetType().GetProperty(property).GetValue(o, null));
            }

            if (sortBy == "desc")
            {
                list = list.OrderByDescending(o => o.GetType().GetProperty(property).GetValue(o, null));
            }

            return list;
        }
    }
}
