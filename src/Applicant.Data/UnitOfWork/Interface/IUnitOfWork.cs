using System;
using System.Collections.Generic;
using System.Text;
using Remotion.Linq.Clauses;

namespace Applicant.Data.UnitOfWork.Interface
{
    interface IUnitOfWork : IDisposable 
    {
        void Commit();
    }
}
