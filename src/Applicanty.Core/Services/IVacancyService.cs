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
        void AttachCandidate(VacancyCandidateDto model);
        void ChangeCandidateStage(VacancyCandidateDto model);
        IEnumerable<VacancyCandidateAttachDto> GetByTechnologyAndExperience(int[] technologyIds, Experience experience);
        IEnumerable<VacancyCandidateAttachDto> GetByCandidate(int candidateId);
    }
}
