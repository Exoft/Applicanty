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
        public CandidateService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {}

        protected override ICandidateRepository InitRepository() =>
            UnitOfWork.CandidateRepository;

        public IEnumerable<CandidateGridDto> GetCandidatesByVacancyStage(int vacancyId, int stageId)
        {
           var candidates = Repository.GetWithInclude(include => include.VacancyCandidates)
                .Where(item=>item.VacancyCandidates.Any(vc => vc.VacancyId == vacancyId && (int)vc.VacancyStage == stageId));

            return Mapper.Map<IEnumerable<Candidate>, IEnumerable<CandidateGridDto>>(candidates);
        }
    }
}