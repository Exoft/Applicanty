using System;

namespace Applicanty.Core.Dto
{
    public class VacancyCreateDto
    {
        public int Id { get; set; }
        public int ExperienceId { get; set; }
        public int PriorityId { get; set; }
        public string Title { get; set; }
        public string JobDescription { get; set; }
        public string VacancyDescription { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }
        public int[] TechnologyIds { get; set; }
        public string CommentText { get; set; }
    }
}