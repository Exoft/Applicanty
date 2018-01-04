using Applicanty.Core.Model;
using AutoMapper;
using System;

namespace Applicanty.DTO.DtoModel
{
    public class CandidateDetailsDTO
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
