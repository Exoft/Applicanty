using Applicanty.Data.Entity;

namespace Applicanty.Data.Repositories
{
    public class StatusRepository : StateableRepository<Status, int>, IStatusRepository
    {
        public StatusRepository(AtsDbContext context) 
            : base(context)
        {
        }
    }
}
