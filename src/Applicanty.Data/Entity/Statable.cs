using Applicanty.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applicanty.Data.Repositories
{
    public abstract class Statable : IStateable
    {
        public bool IsArchived { get; set; }
    }

}
