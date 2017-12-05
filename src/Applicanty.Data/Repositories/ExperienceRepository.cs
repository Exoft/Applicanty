using Applicanty.Data.Entity;

namespace Applicanty.Data.Repositories
{
    public class ExperienceRepository : EntityBaseRepository<Experience, int>, IExperienceRepository
    {
        public ExperienceRepository(AtsDbContext context) 
            : base(context)
        {
        }
    }

}
