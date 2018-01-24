using Applicanty.Core.Data;
using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Entities;
using Applicanty.Core.Services;
using AutoMapper;

namespace Applicanty.Services.Services
{
    public class VacancyCandidateService : BaseService<VacancyCandidate, IVacancyCandidateRepository>, IVacancyCandidateService
    {
        public VacancyCandidateService(IUnitOfWork unitOfWork, IMapper mapper) 
            : base(unitOfWork, mapper)
        {}

        protected override IVacancyCandidateRepository InitRepository()=>
            UnitOfWork.VacancyCandidateRepository;

    }
}