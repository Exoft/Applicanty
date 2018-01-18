using System.Collections.Generic;

namespace Applicanty.Core.Responses
{
    public class Response<T>
    {
        public IEnumerable<T> Result { get; set; }
        public int TotalCount { get; set; }
    }
}
