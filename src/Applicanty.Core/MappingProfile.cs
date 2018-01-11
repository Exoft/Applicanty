using Applicanty.Core.Dto;
using Applicanty.Core.Entities;
using AutoMapper;

namespace Applicanty.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            #region UserMap
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<User, UserDetailsDto>();
            CreateMap<UserDetailsDto, User>();

            CreateMap<User, UserCreateDto>();
            CreateMap<UserCreateDto, User>();

            CreateMap<User, UserUpdateDto>();
            CreateMap<UserUpdateDto, User>();
            #endregion

            #region CandidateMap
            CreateMap<Candidate, CandidateDto>();
            CreateMap<Candidate, CandidateDto>();

            CreateMap<Candidate, CandidateDetailsDto>();
            CreateMap<CandidateDetailsDto, Candidate>();

            CreateMap<Candidate, CandidateCreateDto>();
            CreateMap<Candidate, CandidateCreateDto>();

            CreateMap<Candidate, CandidateUpdateDto>();
            CreateMap<CandidateUpdateDto, Candidate>();
            #endregion

            #region VacancyMap
            CreateMap<Vacancy, VacancyDto>();
            CreateMap<VacancyDto, Vacancy>();

            CreateMap<Vacancy, VacancyDetailsDto>();
            CreateMap<VacancyDetailsDto, Vacancy>();

            CreateMap<Vacancy, VacancyCreateDto>();
            CreateMap<VacancyCreateDto, Vacancy>();

            CreateMap<Vacancy, VacancyUpdateDto>();
            CreateMap<VacancyUpdateDto, Vacancy>();
            #endregion

            #region ExperienceMap
            CreateMap<Experience, ExperienceDto>();
            CreateMap<ExperienceDto, Experience>();

            CreateMap<Experience, ExperienceCreateOrUpdateDto>();
            CreateMap<ExperienceCreateOrUpdateDto, Experience>();
            #endregion

            #region TechnologyMap
            CreateMap<Technology, TechnologyDto>();
            CreateMap<TechnologyDto, Technology>();

            CreateMap<Technology, TechnologyCreateOrUpdateDto>();
            CreateMap<TechnologyCreateOrUpdateDto, Technology>();
            #endregion

            #region StatusMap
            CreateMap<Status, StatusDto>();
            CreateMap<StatusDto, Status>();

            CreateMap<Status, StatusCreateOrUpdateDto>();
            CreateMap<StatusCreateOrUpdateDto, Status>();
            #endregion
        }
    }
}
