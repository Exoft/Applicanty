using Applicanty.Core.Entities;
using System.Collections.Generic;

namespace Applicanty.Core.Services
{
    public interface IVacancyCandidateService : IService<VacancyCandidate>
    {
        IEnumerable<VacancyCandidate> GetByVacancy(int vacancyId);
        IEnumerable<VacancyCandidate> GetByVacancyAndStage(int vacancyId, int stageId);
    }
}