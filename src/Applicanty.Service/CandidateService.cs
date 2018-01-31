using Applicanty.Core.Data;
using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Dto;
using Applicanty.Core.Entities;
using Applicanty.Core.Services;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Applicanty.Services.Services
{
    public class CandidateService : TrackableService<Candidate, ICandidateRepository>, ICandidateService
    {
        private IVacancyCandidateService _vacancyCandidateService;

        public CandidateService(IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IVacancyCandidateService vacancyCandidateService)
            : base(unitOfWork, mapper)
        {
            _vacancyCandidateService = vacancyCandidateService;
        }

        protected override ICandidateRepository InitRepository() =>
            UnitOfWork.CandidateRepository;

        public IEnumerable<CandidateGridDto> GetCandidatesByVacancyStage(int vacancyId, int stageId)
        {
            var candidatsIdArray = _vacancyCandidateService
                .GetByVacancyAndStage(vacancyId, stageId)
                .Select(f=>f.CandidateId).ToArray();

            return GetAll<CandidateGridDto>(f=>candidatsIdArray.Contains(f.Id));
        }
    }
}