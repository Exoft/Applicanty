using Applicanty.Core.Model;
using Applicanty.Data.Repositories.Abstract;

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
