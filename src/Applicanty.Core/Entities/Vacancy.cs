using Applicanty.Core.Entities.Abstract;
using Applicanty.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Applicanty.Core.Entities
{
    public class Vacancy : Statable, IEntity, ITrackable
    {
        public Vacancy()
        {
            VacancyCandidates = new HashSet<VacancyCandidate>();
            VacancyTechnologies = new HashSet<VacancyTechnology>();
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        [ForeignKey("User")]
        public int CreatedBy { get; set; }
        public Experience ExperienceId { get; set; }
        public Priority PriorityId { get; set; }
        public string Title { get; set; }
        public string JobDescription { get; set; }
        public string VacancyDescription { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ModifiedBy { get; set; }

        public User User { get; set; }
        public ICollection<VacancyCandidate> VacancyCandidates { get; set; }
        public ICollection<VacancyTechnology> VacancyTechnologies { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}