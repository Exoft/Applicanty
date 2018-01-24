using Applicanty.Core.Data;
using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Entities;
using Applicanty.Core.Services;
using AutoMapper;

namespace Applicanty.Services.Services
{
    public class CandidateService : TrackableService<Candidate, ICandidateRepository>, ICandidateService
    {
        public CandidateService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        protected override ICandidateRepository InitRepository() =>
            UnitOfWork.CandidateRepository;
    }
}