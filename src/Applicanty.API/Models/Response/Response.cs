using System.Collections.Generic;

namespace Applicanty.API.Models.Response
{
    public class Response<T>
    {
        public IEnumerable<T> Result { get; set; }
        public int TotalCount { get; set; }
    }
}
