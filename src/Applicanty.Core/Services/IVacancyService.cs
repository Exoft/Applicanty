using Applicanty.Core.Dto;
using Applicanty.Core.Dto.VacancyCandidate;
using Applicanty.Core.Entities;
using Applicanty.Core.Enums;
using System.Collections.Generic;

namespace Applicanty.Core.Services
{
    public interface IVacancyService : IStateableService<Vacancy>
    {
        List<StageCandidatesCountDto> CountVacancyStageCandidates(int id);
        void AttachCandidat(VacancyCandidateDto model);
        void ChangeCandidatStage(VacancyCandidateDto model);
    }
}
