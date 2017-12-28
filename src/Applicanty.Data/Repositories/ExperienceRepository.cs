using Applicanty.Core.Model;
using Applicanty.Data.Repositories.Abstract;

namespace Applicanty.Data.Repositories
{
    internal class ExperienceRepository : EntityBaseRepository<Experience>, IExperienceRepository
    {
        public ExperienceRepository(AtsDbContext context) 
            : base(context)
        {
        }
    }

}
