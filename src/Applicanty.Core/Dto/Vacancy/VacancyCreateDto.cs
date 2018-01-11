using System;
using System.Collections.Generic;
using System.Text;

namespace Applicanty.Core.Dto
{
    public class VacancyCreateDto
    {
        public int UserId { get; set; }
        public int ExperienceId { get; set; }
        public string Title { get; set; }
        public string JobDescription { get; set; }
        public string ProjectDescription { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime EndDate { get; set; }
        public List<TechnologyDto> Technologies { get; set; }
    }
}
