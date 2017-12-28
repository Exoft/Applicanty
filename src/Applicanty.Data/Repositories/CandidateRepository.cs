using Applicanty.Core.Model;
using Applicanty.Data.Repositories.Abstract;

namespace Applicanty.Data.Repositories
{
    internal class CandidateRepository : StateableRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(AtsDbContext context)
            : base(context)
        { }
    }
}
