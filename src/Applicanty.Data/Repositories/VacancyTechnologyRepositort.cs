using Applicanty.Core.Entities;
using Applicanty.Core.Data.Repositories;

namespace Applicanty.Data.Repositories
{
    internal class VacancyTechnologyRepositort : EntityBaseRepository<VacancyTechnology>, IVacancyTechnologyRepositort
    {
        public VacancyTechnologyRepositort(AtsDbContext context) 
            : base(context)
        {}
    }
}
