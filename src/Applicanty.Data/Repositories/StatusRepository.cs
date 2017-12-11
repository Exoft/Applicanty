using Applicanty.Data.Entity;

namespace Applicanty.Data.Repositories
{
    public class StatusRepository : StatableRepository<Status, int>, IStatusRepository
    {
        public StatusRepository(AtsDbContext context) 
            : base(context)
        {
        }
    }
}
