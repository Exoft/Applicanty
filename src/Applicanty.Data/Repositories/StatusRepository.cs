using Applicanty.Data.Entity;

namespace Applicanty.Data.Repositories
{
    public class StatusRepository : EntityBaseRepository<Status, int>, IStatusRepository
    {
        public StatusRepository(AtsDbContext context) : base(context)
        {
        }
    }
}
