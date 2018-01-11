using System.Collections.Generic;
using Applicanty.Core.Entities.Abstract;
using Applicanty.Core.Data;
using Applicanty.Services.Abstract;
using AutoMapper;
using Applicanty.Core.Data.Repositories;

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

        public virtual void Archive(int id)
        {
            Repository.Archive(id);
            UnitOfWork.Commit();
        }

        public virtual void Archive(ICollection<TEntity> list)
        {
            Repository.Archive(list);
            UnitOfWork.Commit();
        }

        public virtual void UnArchive(int id)
        {
            Repository.UnArchive(id);
            UnitOfWork.Commit();
        }

        public virtual void UnArchive(ICollection<TEntity> list)
        {
            Repository.UnArchive(list);
            UnitOfWork.Commit();
        }
    }
}
