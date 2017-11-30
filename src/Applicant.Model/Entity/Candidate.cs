using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Applicant.Model.Entity
{
    public class Candidate : IPrimary<long>
    {
        public long Id { get; set; }
        [Required,ForeignKey("Experience")]
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
        public ICollection<Vacancy> Vacancies { get; set; }
        public ICollection<Technology> Technologies { get; set; }
    }
}
