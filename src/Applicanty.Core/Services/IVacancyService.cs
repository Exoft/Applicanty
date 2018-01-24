using Applicanty.Core.Dto.VacancyCandidate;
using Applicanty.Core.Entities;
using System.Collections.Generic;

namespace Applicanty.Core.Services
{
    public interface IVacancyService : IStateableService<Vacancy>
    {
        List<StageCandidatesCountDto> CountVacancyStageCandidates(int id);
    }
}
