using Applicanty.Core.Dto;
using Applicanty.Core.Entities;
using AutoMapper;
using System;
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

            CreateMap<Candidate, CandidateCreateUpdateDto>()
                .ForMember(dest => dest.TechnologyIds,
                    opts => opts.MapFrom(src => src.CandidateTechnologies.Select(f => f.TechnologyId)));

            CreateMap<CandidateVacancyAttachDto, Candidate>();
            CreateMap<Candidate, CandidateVacancyAttachDto>()
                .ForMember(dest => dest.FullName,
                    opts => opts.MapFrom(src => string.Format($"{src.FirstName} {src.LastName}")));

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

            #region CommentMap
            CreateMap<Comment, VacancyUpdateDto>();
            CreateMap<VacancyUpdateDto, Comment>()
                .ForMember(dest => dest.VacancyId, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, opts => opts.Ignore());

            CreateMap<VacancyUpdateDto, VacancyWithCommentsDto>();
            CreateMap<VacancyWithCommentsDto, VacancyUpdateDto>();

            #endregion

            #region TechnologyMap
            CreateMap<Technology, TechnologyDto>();
            CreateMap<TechnologyDto, Technology>();

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