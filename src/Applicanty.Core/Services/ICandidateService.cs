using Applicanty.Core.Dto;
using Applicanty.Core.Entities;
using Applicanty.Core.Enums;
using System.Collections.Generic;

namespace Applicanty.Core.Services
{
    public interface ICandidateService : IStateableService<Candidate>
    {
        IEnumerable<CandidateGridDto> GetByVacancy(int vacancyId, int stageId);
        IEnumerable<CandidateVacancyAttachDto> GetByVacancy(int vacancyId);
        IEnumerable<CandidateVacancyAttachDto> GetByTechnologyAndExperience(int[] technologyIds, Experience experience);
    }
}
