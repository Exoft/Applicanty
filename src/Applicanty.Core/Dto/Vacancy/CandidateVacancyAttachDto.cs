using Applicanty.Core.Enums;

namespace Applicanty.Core.Dto
{
    public class CandidateVacancyAttachDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public VacancyStage VacancyStage { get; set; }
    }
}
