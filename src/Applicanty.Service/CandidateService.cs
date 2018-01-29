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

        public IEnumerable<CandidateGridDto> GetCandidatesByVacancyStage(int idVacancy, int idStage)
        {
            var candidatsIdArray = _vacancyCandidateService
                .GetAll<VacancyCandidateDto>(f => f.VacancyId == idVacancy && (int)f.VacancyStage == idStage)
                .Select(f=>f.CandidateId).ToArray();

            return GetAll<CandidateGridDto>(f=>candidatsIdArray.Contains(f.Id));
        }
    }
}