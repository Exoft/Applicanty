using Applicanty.Core.Entities;
using Applicanty.Core.Data.Repositories;

namespace Applicanty.Data.Repositories
{
    internal class ExperienceRepository : EntityBaseRepository<Experience>, IExperienceRepository
    {
        internal ExperienceRepository(AtsDbContext context)
            : base(context)
        {
        }
    }
}
