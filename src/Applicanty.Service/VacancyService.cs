using Applicanty.Core.Data;
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

        public VacancyService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        protected override IVacancyRepository InitRepository() =>
             UnitOfWork.VacancyRepository;

        public List<StageCandidatesCountDto> CountVacancyStageCandidates(int id)
        {
            var vacancyCandidates = Repository.GetWithInclude(f => f.VacancyCandidates)
                                              .FirstOrDefault(f => f.Id == id).VacancyCandidates;

            return vacancyCandidates
                    .GroupBy(item => item.VacancyStage)
                    .Select(item => new StageCandidatesCountDto { Stage = item.Key, Count = item.Count() }).ToList();
        }

        public void AttachCandidate(VacancyCandidateDto model)
        {
            if (model == null)
                throw new System.ArgumentNullException(nameof(model));

            var vacancy = GetOne<Vacancy>(model.VacancyId);
            vacancy.VacancyCandidates.Add(Mapper.Map<VacancyCandidateDto, VacancyCandidate>(model));

            UnitOfWork.Commit();
        }

        public void ChangeCandidateStage(VacancyCandidateDto model)
        {
            var vacancy = GetOne<Vacancy>(model.VacancyId);

            vacancy.VacancyCandidates.Append(Mapper.Map<VacancyCandidateDto, VacancyCandidate>(model));
            Repository.Update(vacancy);

            UnitOfWork.Commit();
        }

        public override TDto Update<TDto>(TDto dto)
        {
            var vacancyDto = dto as VacancyUpdateDto;

            if (vacancyDto == null)
                throw new System.ArgumentNullException(nameof(vacancyDto));

            var entity = Mapper.Map<TDto, Vacancy>(dto);

            foreach (var technologyId in vacancyDto.TechnologyIds)
                entity.VacancyTechnologies.Add(new VacancyTechnology
                                        { VacancyId = entity.Id, TechnologyId = technologyId });

            var updatedEntity = Repository.Update(entity);
            UnitOfWork.Commit();

            return Mapper.Map<Vacancy, TDto>(updatedEntity);
        }

        public override TDto Create<TDto>(TDto dto)
        {
            var vacancyDto = dto as VacancyCreateDto;

            if (vacancyDto == null)
                throw new System.ArgumentNullException(nameof(vacancyDto));

            var entity = Mapper.Map<TDto, Vacancy>(dto);
            var createdEntity = Repository.Create(entity);

            UnitOfWork.Commit();

            foreach (var technologyId in vacancyDto.TechnologyIds)
                createdEntity.VacancyTechnologies.Add(new VacancyTechnology()
                                { VacancyId = createdEntity.Id, TechnologyId = technologyId });

            UnitOfWork.Commit();

            return Mapper.Map<Vacancy, TDto>(createdEntity);
        }
    }
}