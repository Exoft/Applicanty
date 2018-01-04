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
    public class StatusService : BaseService<Status>, IStatusService
    {
        public StatusService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {}

        public override void Create(Status entity)
        {
            UnitOfWork.StatusRepository.Add(entity);
            UnitOfWork.Commit();
        }

        public override IEnumerable<StatusDTO> GetAll<StatusDTO>()
        {
            var entity = UnitOfWork.StatusRepository.GetAll();
            return Mapper.Map<IEnumerable<Status>,IEnumerable<StatusDTO>>(entity);
        }

        public override ICollection<StatusDTO> GetAll<StatusDTO>(Expression<Func<Status, bool>> predicate)
        {
            var entity = UnitOfWork.StatusRepository.GetAll(predicate);
            return Mapper.Map<ICollection<Status>,ICollection<StatusDTO>>(entity);
        }

        public override StatusDTO GetOne<StatusDTO>(int id)
        {
            var entity = UnitOfWork.StatusRepository.GetOne(id);
            return Mapper.Map<Status, StatusDTO>(entity);
        }

        public override StatusDTO GetOne<StatusDTO>(Expression<Func<Status, bool>> predicate)
        {
            var entity =UnitOfWork.StatusRepository.GetOne(predicate);
            return Mapper.Map<Status, StatusDTO>(entity);

        }

        public override void Update(Status entity)
        {
            UnitOfWork.StatusRepository.Update(entity);
            UnitOfWork.Commit();
        }

        protected override IEntityBaseRepository<Status> InitRepository()
        {
            throw new NotImplementedException();
        }
    }
}