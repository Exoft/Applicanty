using System;
using System.Collections.Generic;
using System.Text;
using Remotion.Linq.Clauses;

namespace Applicanty.Data.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable 
    {
        void Commit();
    }
}
