using Applicanty.Core.Model;
using Applicanty.DTO.DtoModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applicanty.DTO
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<User, UserDetailsDTO>();
            CreateMap<UserDetailsDTO, User>();

            CreateMap<Technology, TechnologyDTO>();
            CreateMap<TechnologyDTO, Technology>();

            CreateMap<Experience, ExperienceDTO>();
            CreateMap<ExperienceDTO, Experience>();

            CreateMap<Candidate, CandidateDTO>();
            CreateMap<CandidateDTO, CandidateDTO>();

            CreateMap<Candidate, CandidateDetailsDTO>();
            CreateMap<CandidateDetailsDTO, Candidate>();

            CreateMap<Vacancy, VacancyDetailsDTO>();
            CreateMap<VacancyDetailsDTO, Vacancy>();

            CreateMap<Vacancy, VacancyDTO>();
            CreateMap<VacancyDTO, Vacancy>();
        }
    }
}
