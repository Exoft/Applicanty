using Applicanty.Data.Entity.Abstract;
using Applicanty.Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Applicanty.Data.Entity
{
    public class Vacancy : Statable,IPrimary<long>
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

        public User User { get; set; }
        public Experience Experiences { get; set; }
        public ICollection<VacancyCandidate> VacancyCandidats { get; set; }
        public ICollection<VacancyTechnology> VacancyTecnologies { get; set; }
    }
}
