using Applicanty.Data.Entity;

namespace Applicanty.Data.Repositories
{
    public class VacancyRepository: StateableRepository<Vacancy, long>, IVacancyRepository
    {
        public VacancyRepository(AtsDbContext context) 
            : base(context)
        {
        }
    }
}
