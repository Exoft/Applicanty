using Applicanty.Core.Entities;
using AutoMapper;

namespace Applicanty.Core.Dto
{
    public class CandidateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ExperienceId { get; set; }
        public int LastVacancyId { get; set; }
        public string Email { get; set; }
        public string LinkedIn { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
    }
}
