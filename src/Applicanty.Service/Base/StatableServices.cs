﻿using Applicanty.Core.Data;
using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Entities.Abstract;
using Applicanty.Core.Services;
using AutoMapper;

namespace Applicanty.Services.Services
{
    public abstract class StateableService<TEntity, TRepository > : BaseService<TEntity, TRepository>, 
        IStateableService<TEntity>
        where TRepository:IStateableRepository<TEntity>
        where TEntity : class, IEntity, IStateable
    {
        public StateableService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {}

        public virtual void ChangeStatus(int[] arrayIds, string status)
        {
            Repository.ChangeStatus(arrayIds, status);
            UnitOfWork.Commit();
        }
    }
}