using Applicanty.Core.Entities;
using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Data;
using Applicanty.Services.Abstract;
using AutoMapper;

namespace Applicanty.Services.Services
{
    public class CandidateService : StateableService<Candidate, ICandidateRepository>, ICandidateService
    {
        public CandidateService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        protected override ICandidateRepository InitRepository() =>
            UnitOfWork.CandidateRepository;

    }
}
