using System;

namespace Applicanty.Core.Dto
{
    public class VacancyDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ExperienceId { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsArchived { get; set; }
    }
}
