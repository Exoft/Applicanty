using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Applicant.Model.Entity
{
    public class Vacancy:IPrimary<long>
    {
        public long Id { get; set; }
        [Required, ForeignKey("User")]
        public long IdUser { get; set; }
        [Required, ForeignKey("Experience")]
        public int IdExperience { get; set; }
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

        public User User { get; set; }
        public Experience Experiences { get; set; }
        public ICollection<Candidate> Candidates { get; set; }
        public ICollection<Technology> Technologies { get; set; }
    }
}
