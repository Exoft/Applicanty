using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicant.Model.Entity
{
    public interface IPrimary<TKey>
    {
        TKey Id { get; set; }
    }
}
