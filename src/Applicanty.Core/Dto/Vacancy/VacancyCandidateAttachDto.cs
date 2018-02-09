using Applicanty.Core.Enums;

namespace Applicanty.Core.Dto
{
    public class VacancyCandidateAttachDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public VacancyStage VacancyStage { get; set; }
    }
}