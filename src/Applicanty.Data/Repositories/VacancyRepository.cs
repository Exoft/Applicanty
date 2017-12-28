using Applicanty.Core.Model;
using Applicanty.Data.Repositories.Abstract;

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
