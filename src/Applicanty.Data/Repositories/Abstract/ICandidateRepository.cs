using Applicanty.Data.Entity;

namespace Applicanty.Data.Repositories
{ 
    public interface ICandidateRepository : IEntityBaseRepository<Candidate, long>
    {
    }
}