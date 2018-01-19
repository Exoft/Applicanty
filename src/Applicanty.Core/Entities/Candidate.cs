using Applicanty.Core.Entities.Abstract;
using Applicanty.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Applicanty.Core.Entities
{
    public class Candidate : Statable, IEntity
    {
        public int Id { get; set; }
        public Experience ExperienceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string LinkedIn { get; set; }
        public string Phone { get; set; }
        public string CVPath { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CtreatedAt { get; set; }
        [ForeignKey("User")]
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }

        public ICollection<VacancyCandidate> VacancyCandidates { get; set; }
        public ICollection<CandidateTechnology> CandidateTechnologies { get; set; }
    }
}