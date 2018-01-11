using System;
using System.Collections.Generic;
using System.Text;

namespace Applicanty.Core.Dto
{
    public class CandidateUpdateDto
    {
        public int ExperienceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string LinkedIn { get; set; }
        public string Phone { get; set; }
        public string CVPath { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime UpdateOn { get; set; }
    }
}
