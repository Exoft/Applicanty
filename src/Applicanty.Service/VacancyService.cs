﻿using Applicanty.Core.Data;
using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Dto;
using Applicanty.Core.Dto.VacancyCandidate;
using Applicanty.Core.Entities;
using Applicanty.Core.Services;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Applicanty.Services.Services
{
    public class VacancyService : TrackableService<Vacancy, IVacancyRepository>, IVacancyService
    {
        private IVacancyCandidateService _vacancyCandidateService;

        public VacancyService(IUnitOfWork unitOfWork, IMapper mapper, IVacancyCandidateService vacancyCandidateService)
            : base(unitOfWork, mapper)
        {
            _vacancyCandidateService = vacancyCandidateService;
        }

        protected override IVacancyRepository InitRepository() =>
             UnitOfWork.VacancyRepository;

        public List<StageCandidatesCountDto> CountVacancyStageCandidates(int id)
        {
            var vacancyCandidates = _vacancyCandidateService.GetAll<VacancyCandidateDto>(f => f.VacancyId == id);

            return vacancyCandidates
                .GroupBy(item => item.VacancyStage)
                .Select(item => new StageCandidatesCountDto { Stage = item.Key, Count = item.Count() }).ToList();
            }
    }
}