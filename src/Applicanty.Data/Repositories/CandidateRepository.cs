using Applicanty.Data.Entity;

namespace Applicanty.Data.Repositories
{
    public class CandidateRepository : StateableRepository<Candidate, long>, ICandidateRepository
    {
        public CandidateRepository(AtsDbContext context) 
            : base(context)
        {}
    }
}
