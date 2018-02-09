using Applicanty.Core.Dto;
using Applicanty.Core.Entities;
using AutoMapper;
using System.Linq;

namespace Applicanty.Core
{
    public class MappingProfile : Profile
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

            CreateMap<Vacancy, VacancyCreateDto>();
            CreateMap<VacancyCreateDto, Vacancy>();

            CreateMap<Vacancy, VacancyUpdateDto>()
                .ForMember(dest => dest.TechnologyIds,
                    opts => opts.MapFrom(src => src.VacancyTechnologies.Select(f => f.TechnologyId)));

            CreateMap<VacancyUpdateDto, Vacancy>();

            CreateMap<Vacancy, VacancyCandidateAttachDto>();
            CreateMap<VacancyCandidateAttachDto, Vacancy>();
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

            #region VacancyTechnology
            CreateMap<VacancyTechnologyDto, VacancyTechnology>();
            CreateMap<VacancyTechnology, VacancyTechnologyDto>();
            #endregion

            #region VacancyCandidate
            CreateMap<VacancyCandidate, VacancyCandidateDto>();
            CreateMap<VacancyCandidateDto, VacancyCandidate>();
            #endregion
        }
    }
}