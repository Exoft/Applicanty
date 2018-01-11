using Applicanty.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Applicanty.Core.Dto
{
    public class VacancyDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string VacancyDescription { get; set; }
        public string JobDescription { get; set; }
        public int UserId { get; set; }
        public int ExperienceId { get; set; }
        public int StatusId { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }
        public List<TechnologyDto> Technologies { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsArchived { get; set; }
    }
}
