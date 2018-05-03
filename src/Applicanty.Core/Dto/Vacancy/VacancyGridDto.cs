using Applicanty.Core.Enums;
using System;

namespace Applicanty.Core.Dto
{
    public class VacancyGridDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ExperienceId { get; set; }
        public int PriorityId { get; set; }
        public StatusType StatusId { get; set; }
    }
}
