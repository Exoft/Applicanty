using Applicanty.Data.Entity;

namespace Applicanty.Data.Repositories
{
    public class TechnologyRepository : EntityBaseRepository<Technology, int>, ITechnologyRepository
    {
        public TechnologyRepository(AtsDbContext context) 
            : base(context)
        {
        }
    }
}
