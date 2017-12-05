using System;
using System.Collections.Generic;
using Applicanty.Data.UnitOfWork.Interface;
using Applicanty.Data.Repositories;

namespace Applicanty.Data.Services
{
    public abstract class EntityService<TEntity, TKey> : IEntityService<TEntity> where TEntity : class
    {

        IUnitOfWork _unitOfWork;
        IEntityBaseRepository<TEntity, TKey>  _repository ;

        protected EntityService(IUnitOfWork unitOfWork, IEntityBaseRepository<TEntity, TKey> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        void IEntityService<TEntity>.Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void IEntityService<TEntity>.Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TEntity> IEntityService<TEntity>.GetAll()
        {
            throw new NotImplementedException();
        }

        void IEntityService<TEntity>.Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
