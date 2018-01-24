using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Entities;

namespace Applicanty.Data.Repositories
{
    internal class VacancyCandidateRepository : EntityBaseRepository<VacancyCandidate>, IVacancyCandidateRepository
    {
        public VacancyCandidateRepository(AtsDbContext context) : base(context)
        {
        }
    }
}
