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
    public class TechnologyService : BaseService<Technology>, ITechnologyService
    {
        public TechnologyService(IUnitOfWork unitOfWork, IMapper mapper)
            :base(unitOfWork,mapper)
        {}

        public override void Create(Technology entity)
        {
            UnitOfWork.TechnologyRepository.Add(entity);
            UnitOfWork.Commit();
        }

        public override IEnumerable<TechnologyDTO> GetAll<TechnologyDTO>()
        {
            var entity = UnitOfWork.TechnologyRepository.GetAll();
            return Mapper.Map<IEnumerable<Technology>,IEnumerable<TechnologyDTO>>(entity);
        }

        public override ICollection<TechnologyDTO> GetAll<TechnologyDTO>(Expression<Func<Technology, bool>> predicate)
        {
            var entity = UnitOfWork.TechnologyRepository.GetAll(predicate);
            return Mapper.Map<ICollection<Technology>, ICollection<TechnologyDTO>>(entity);
        }

        public override TechnologyDTO GetOne<TechnologyDTO>(int id)
        {
            var entity = UnitOfWork.TechnologyRepository.GetOne(id);
            return Mapper.Map<Technology,TechnologyDTO>(entity);
        }

        public override TechnologyDTO GetOne<TechnologyDTO>(Expression<Func<Technology, bool>> predicate)
        {
            var entity = UnitOfWork.TechnologyRepository.GetOne(predicate);
            return Mapper.Map<Technology, TechnologyDTO>(entity);

        }

        public override void Update(Technology entity)
        {
            UnitOfWork.TechnologyRepository.Update(entity);
            UnitOfWork.Commit();
        }

        protected override IEntityBaseRepository<Technology> InitRepository()
        {
            throw new NotImplementedException();
        }
    }
}
