using Applicanty.Core.Model;
using Applicanty.Data.Repositories.Abstract;

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
