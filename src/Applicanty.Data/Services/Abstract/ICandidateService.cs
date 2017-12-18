using Applicanty.Data.Entity;
using Applicanty.Data.Services.Abstract;

namespace Applicanty.Data.Services
{
    public interface ICandidateService : IStateableServices<Candidate, long>
    {
        
    }
}
