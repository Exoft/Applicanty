using Applicant.Data.Entity;

namespace Applicant.Data.Repositories
{
    public class VacancyRepository: EntityBaseRepository<Vacancy, long>
    {
        public VacancyRepository(AtsDbContext context) : base(context)
        {
        }
    }
}
