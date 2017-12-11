using Applicanty.Data.Entity;

namespace Applicanty.Data.Repositories
{
    public class CandidateRepository : StatableRepository<Candidate, long>, ICandidateRepository
    {
        public CandidateRepository(AtsDbContext context) 
            : base(context)
        {}
    }
}
