using Applicanty.Data.Entity.Abstract;
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
        [ForeignKey("Experience")]
        public int ExperienceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string LinkedIn { get; set; }
        public string Phone { get; set; }
        public string CVPath { get; set; }
        public DateTime UpdateOn { get; set; }

        public Experience Experience { get; set; }
        public ICollection<VacancyCandidate> VacancyCandidates { get; set; }
        public ICollection<CandidateTechnology> CandidateTechnologies { get; set; }
    }
}
