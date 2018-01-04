using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Applicanty.Core.Entities;
using Applicanty.Core.Data;
using Applicanty.Services.Abstract;
using AutoMapper;
using Applicanty.Core.Data.Repositories;

namespace Applicanty.Services.Services
{
    public class ExperienceService : BaseService<Experience>, IExperienceService
    {
        public ExperienceService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override void Create(Experience entity)
        {
            UnitOfWork.ExperienceRepository.Add(entity);
            UnitOfWork.Commit();
        }

        public override IEnumerable<ExperienceDTO> GetAll<ExperienceDTO>()
        {
            var entity = UnitOfWork.ExperienceRepository.GetAll();
            return Mapper.Map<IEnumerable<Experience>, IEnumerable<ExperienceDTO>>(entity);
        }

        public override ICollection<ExperienceDTO> GetAll<ExperienceDTO>(Expression<Func<Experience, bool>> predicate)
        {
            var entity = UnitOfWork.ExperienceRepository.GetAll(predicate);
            return Mapper.Map<ICollection<Experience>, ICollection<ExperienceDTO>>(entity);

        }

        public override ExperienceDTO GetOne<ExperienceDTO>(int id)
        {
            var entity = UnitOfWork.ExperienceRepository.GetOne(id);
            return Mapper.Map<Experience, ExperienceDTO>(entity);
        }

        public override ExperienceDTO GetOne<ExperienceDTO>(Expression<Func<Experience, bool>> predicate)
        {
            var entity = UnitOfWork.ExperienceRepository.GetOne(predicate);
            return Mapper.Map<Experience, ExperienceDTO>(entity);

        }

        public override void Update(Experience entity)
        {
            UnitOfWork.ExperienceRepository.Update(entity);
            UnitOfWork.Commit();
        }

        protected override IEntityBaseRepository<Experience> InitRepository()
        {
            throw new NotImplementedException();
        }
    }
}
