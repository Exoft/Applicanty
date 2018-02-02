using Applicanty.Core.Entities;
using Applicanty.Core.Data.Repositories;
using System.Security.Principal;

namespace Applicanty.Data.Repositories
{
    internal class VacancyRepository: TrackableRepository<Vacancy>, IVacancyRepository
    {
        public VacancyRepository(AtsDbContext context, IPrincipal principal) 
            : base(context, principal)
        {}
    }
}