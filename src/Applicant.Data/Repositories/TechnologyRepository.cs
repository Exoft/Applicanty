using Applicant.Data.Entity;

namespace Applicant.Data.Repositories
{
    public class TechnologyRepository : EntityBaseRepository<Technology, int>, ITechnologyRepository
    {
        public TechnologyRepository(AtsDbContext context) : base(context)
        {
        }
    }
}
