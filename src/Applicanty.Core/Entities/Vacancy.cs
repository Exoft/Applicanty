﻿using Applicanty.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Applicanty.Core.Entities
{
    public class Vacancy : Statable, IEntity
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Experience")]
        public int ExperienceId { get; set; }
        public string Title { get; set; }
        public string JobDescription { get; set; }
        public string ProjectDescription { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime EndDate { get; set; }

        public User User { get; set; }
        public Experience Experience { get; set; }
        public ICollection<VacancyCandidate> VacancyCandidates { get; set; }
        public ICollection<VacancyTechnology> VacancyTechnologies { get; set; }
    }
}