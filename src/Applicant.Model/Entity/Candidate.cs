using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Applicant.Model.Entity
{
    public class Candidate : IPrimary<long>
    {
        public long Id { get; set; }
        [Required]
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
    }
}
