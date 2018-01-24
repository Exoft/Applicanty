using Applicanty.Core.Enums;

namespace Applicanty.Core.Dto
{
    public class VacancyCandidateDto
    {
        public int VacancyId { get; set; }
        public int CandidateId { get; set; }
        public VacancyStage VacancyStage { get; set; }
    }
}
