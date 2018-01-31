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

            CreateMap<User, UserRegisterDto>();
            CreateMap<UserRegisterDto, User>();

            CreateMap<User, UserLoginDto>();
            CreateMap<UserLoginDto, User>();

            CreateMap<User, UserUpdateDto>();
            CreateMap<UserUpdateDto, User>();
            #endregion

            #region CandidateMap
            CreateMap<Candidate, CandidateGridDto>();
            CreateMap<CandidateGridDto, Candidate>();

            CreateMap<Candidate, CandidateDetailsDto>();
            CreateMap<CandidateDetailsDto, Candidate>();

            CreateMap<Candidate, CandidateCreateUpdateDto>();
            CreateMap<CandidateCreateUpdateDto, Candidate>();
            #endregion

            #region VacancyMap
            CreateMap<Vacancy, VacancyGridDto>();
            CreateMap<VacancyGridDto, Vacancy>();

            CreateMap<Vacancy, VacancyDetailsDto>();
            CreateMap<VacancyDetailsDto, Vacancy>();

            CreateMap<Vacancy, VacancyCreateDto>();
            CreateMap<VacancyCreateDto, Vacancy>();

            CreateMap<Vacancy, VacancyUpdateDto>();
            CreateMap<VacancyUpdateDto, Vacancy>();
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

            CreateMap<VacancyTechnologyDto, VacancyTechnology>();
            CreateMap<VacancyTechnology, VacancyTechnologyDto>();
        }
    }
}