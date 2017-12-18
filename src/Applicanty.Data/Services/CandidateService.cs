using Applicanty.Data.Entity;
using Applicanty.Data.Repositories;
using Applicanty.Data.Services.Base;
using Applicanty.Data.UnitOfWork.Interface;

namespace Applicanty.Data.Services
{
    public class CandidateService : StateableServices<Candidate, long>, ICandidateService
    {
        IUnitOfWork _unitOfWork;
        ICandidateRepository _candidateRepository;

        public CandidateService(IUnitOfWork unitOfWork, ICandidateRepository candidateRepository)
            : base(unitOfWork, candidateRepository)
        {
            _unitOfWork = unitOfWork;
            _candidateRepository = candidateRepository;
        }
    }
}
