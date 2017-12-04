using Applicant.Data.Entity;

namespace Applicant.Data.Repositories
{
    public class StatusRepository : EntityBaseRepository<Status, int>, IStatusRepository
    {
        public StatusRepository(AtsDbContext context) : base(context)
        {
        }
    }
}
