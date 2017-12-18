using System;
using System.Collections.Generic;
using Applicanty.Data.UnitOfWork.Interface;
using Applicanty.Data.Repositories;

namespace Applicanty.Data.Services
{
    public abstract class EntityService<TEntity, TKey> : IEntityService<TEntity> 
        where TEntity : class
        where TKey : IEquatable<TKey>
    {

        protected IUnitOfWork _unitOfWork;
        protected IEntityBaseRepository<TEntity, TKey> _repository;

        public EntityService(IUnitOfWork unitOfWork, IEntityBaseRepository<TEntity, TKey> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public virtual void Create(TEntity entity)
        {
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public virtual void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual void Update(TEntity entity)
        {
            _repository.Update(entity);
            _unitOfWork.Commit();
        }
    }
}
