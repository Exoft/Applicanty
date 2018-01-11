using System;

namespace Applicanty.Core.Dto
{
    public class CandidateDetailsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ExperienceId { get; set; }
        public string Email { get; set; }
        public string LinkedIn { get; set; }
        public string Skype { get; set; }
        public string PhoneNumber { get; set; }
        public string CVPath { get; set; }
        public DateTime UpdateOn { get; set; }
    }
}
