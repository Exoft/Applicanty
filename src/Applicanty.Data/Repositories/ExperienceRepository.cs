using Applicanty.Data.Entity;

namespace Applicanty.Data.Repositories
{
    public class ExperienceRepository : PrimaryEntityRepository<Experience, int>, IExperienceRepository
    {
        public ExperienceRepository(AtsDbContext context) 
            : base(context)
        {
        }
    }

}
