using Applicanty.Core.Entities;
using Applicanty.Core.Data.Repositories;

namespace Applicanty.Data.Repositories
{
    internal class TechnologyRepository : EntityBaseRepository<Technology>, ITechnologyRepository
    {
        public TechnologyRepository(AtsDbContext context) 
            : base(context)
        {
        }
    }
}
