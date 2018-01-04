using Applicanty.Core.Entities;
using Applicanty.Core.Data.Repositories;

namespace Applicanty.Data.Repositories
{
    internal class CandidateRepository : StateableRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(AtsDbContext context)
            : base(context)
        { }
    }
}
