﻿using Applicanty.Data.Entity.Abstract;
using Applicanty.Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Applicanty.Data.Entity
{
    public class Candidate : Statable, IPrimary<long>
    {
        public long Id { get; set; }
        [Required, ForeignKey("Experience")]
        public int IdExperience { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Skype { get; set; }
        public string LinkedIn { get; set; }
        [Required]
        public string Phone { get; set; }
        public string CVPath { get; set; }
        public DateTime UpdateOn { get; set; }

        public Experience Experiences { get; set; }
        public ICollection<VacancyCandidate> VacancyCandidats { get; set; }
        public ICollection<CandidateTechnology> CanditatTechnologies { get; set; }
    }
}
