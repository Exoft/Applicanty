using Applicanty.Core.Model;
using AutoMapper;
using System;

namespace Applicanty.DTO.DtoModel
{
    public class VacancyDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ExperienceId { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsArchived { get; set; }
    }
}
