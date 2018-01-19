using System;
using System.Collections.Generic;

namespace Applicanty.Core.Dto
{
    public class VacancyUpdateDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ExperienceId { get; set; }
        public string Title { get; set; }
        public string JobDescription { get; set; }
        public string ProjectDescription { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EndDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }

        public List<TechnologyDto> Technologies { get; set; }
    }
}