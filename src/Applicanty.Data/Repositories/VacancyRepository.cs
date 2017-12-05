using Applicanty.Data.Entity;

namespace Applicanty.Data.Repositories
{
    public class VacancyRepository: EntityBaseRepository<Vacancy, long>, IVacancyRepository
    {
        public VacancyRepository(AtsDbContext context) 
            : base(context)
        {
        }
    }
}
