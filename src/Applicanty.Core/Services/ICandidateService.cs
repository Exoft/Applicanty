using Applicanty.Core.Dto;
using Applicanty.Core.Entities;
using System.Collections.Generic;

namespace Applicanty.Core.Services
{
    public interface ICandidateService : IStateableService<Candidate>
    {
        IEnumerable<CandidateGridDto> GetCandidatesByVacancyStage(int idVacancy, int idStage);
    }
}
