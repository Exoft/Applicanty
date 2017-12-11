using Applicanty.Data.Entity;
using Applicanty.Data.Repositories.Abstract;

namespace Applicanty.Data.Repositories
{
    public class TechnologyRepository : PrimaryEntityRepository<Technology, int>, ITechnologyRepository
    {
        public TechnologyRepository(AtsDbContext context) 
            : base(context)
        {
        }
    }
}
