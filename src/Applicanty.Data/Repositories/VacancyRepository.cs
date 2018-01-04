using Applicanty.Core.Entities;
using Applicanty.Core.Data.Repositories;

namespace Applicanty.Data.Repositories
{
    internal class VacancyRepository: StateableRepository<Vacancy>, IVacancyRepository
    {
        public VacancyRepository(AtsDbContext context) 
            : base(context)
        {
        }
    }
}
