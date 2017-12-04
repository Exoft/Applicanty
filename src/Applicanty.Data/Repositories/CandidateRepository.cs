using Applicanty.Data.Entity;

namespace Applicanty.Data.Repositories
{
    public class CandidateRepository : EntityBaseRepository<Candidate, long>, ICandidateRepository
    {
        public CandidateRepository(AtsDbContext context) 
            : base(context)
        {}
    }
}
