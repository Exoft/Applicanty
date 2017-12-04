using System;
using System.Collections.Generic;
using System.Text;
using Remotion.Linq.Clauses;

namespace Applicanty.Data.UnitOfWork.Interface
{
    interface IUnitOfWork : IDisposable 
    {
        void Commit();
    }
}
