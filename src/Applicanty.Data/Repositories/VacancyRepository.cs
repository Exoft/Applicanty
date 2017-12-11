using Applicanty.Data.Entity;

namespace Applicanty.Data.Repositories
{
    public class VacancyRepository: StatableRepository<Vacancy, long>, IVacancyRepository
    {
        public VacancyRepository(AtsDbContext context) 
            : base(context)
        {
        }
    }
}
