using Applicant.Data.Entity;

namespace Applicant.Data.Repositories
{ 
    public interface ICandidateRepository : IRepository<Candidate, long>
    {
    }
}