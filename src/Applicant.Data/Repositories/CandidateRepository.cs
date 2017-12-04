using Applicant.Data.Entity;

namespace Applicant.Data.Repositories
{
    public class CandidateRepository : EntityBaseRepository<Candidate, long>, ICandidateRepository
    {
        public CandidateRepository(AtsDbContext context) 
            : base(context)
        {}
    }
}
