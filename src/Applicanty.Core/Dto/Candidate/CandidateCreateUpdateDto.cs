using System;

namespace Applicanty.Core.Dto
{
    public class CandidateCreateUpdateDto
    {
        public int Id { get; set; }
        public int ExperienceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string LinkedIn { get; set; }
        public string Phone { get; set; }
        public string CVPath { get; set; }
        public DateTime Birthday { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime CtreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

    }
}
