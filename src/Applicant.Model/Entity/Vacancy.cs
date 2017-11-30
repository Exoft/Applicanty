using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Applicant.Model.Entity
{
    public class Vacancy:IPrimary<long>
    {
        public long Id { get; set; }
        [Required]
        public long IdUser { get; set; }
        [Required]
        public int IdExperience { get; set; }
        [Required]
        public int IdVacancy_Technology { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string JobDescription { get; set; }
        [Required]
        public string ProjectDescription { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsArchived { get; set; }
    }
}
