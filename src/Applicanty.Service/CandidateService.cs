using Applicanty.Core.Data;
using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Dto;
using Applicanty.Core.Entities;
using Applicanty.Core.Services;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Applicanty.Services.Services
{
    public class CandidateService : TrackableService<Candidate, ICandidateRepository>, ICandidateService
    {
        public CandidateService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        protected override ICandidateRepository InitRepository() =>
            UnitOfWork.CandidateRepository;

        public IEnumerable<CandidateGridDto> GetCandidatesByVacancyStage(int vacancyId, int stageId)
        {
            var candidates = Repository.GetWithInclude(include => include.VacancyCandidates)
                 .Where(item => item.VacancyCandidates.Any(vc => vc.VacancyId == vacancyId && (int)vc.VacancyStage == stageId));

            return Mapper.Map<IEnumerable<Candidate>, IEnumerable<CandidateGridDto>>(candidates);
        }

        public override TDto Update<TDto>(TDto dto)
        {
            var candidateDto = dto as CandidateCreateUpdateDto;

            if (candidateDto == null)
                throw new System.ArgumentNullException(nameof(candidateDto));

            var entity = Mapper.Map<TDto, Candidate>(dto);

            foreach (var technologyId in candidateDto.TechnologyIds)
                entity.CandidateTechnologies.Add(new CandidateTechnology
                {
                    CandidateId = entity.Id,
                    TechnologyId = technologyId
                });

            var updatedEntity = Repository.Update(entity);
            UnitOfWork.Commit();

            return Mapper.Map<Candidate, TDto>(updatedEntity);
        }

        public override TDto Create<TDto>(TDto dto)
        {
            var candidateDto = dto as CandidateCreateUpdateDto;

            if (candidateDto == null)
                throw new System.ArgumentNullException(nameof(candidateDto));

            var entity = Mapper.Map<TDto, Candidate>(dto);
            var createdEntity = Repository.Create(entity);

            UnitOfWork.Commit();

            foreach (var technologyId in candidateDto.TechnologyIds)
                createdEntity.CandidateTechnologies.Add(new CandidateTechnology()
                {
                    CandidateId = createdEntity.Id,
                    TechnologyId = technologyId
                });

            UnitOfWork.Commit();

            return Mapper.Map<Candidate, TDto>(createdEntity);
        }
    }
}