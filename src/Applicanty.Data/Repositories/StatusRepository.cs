using Applicanty.Core.Entities;
using Applicanty.Core.Data.Repositories;

namespace Applicanty.Data.Repositories
{
    internal class StatusRepository : StateableRepository<Status>, IStatusRepository
    {
        public StatusRepository(AtsDbContext context) 
            : base(context)
        {
        }
    }
}