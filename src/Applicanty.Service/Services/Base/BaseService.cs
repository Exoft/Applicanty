using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Applicanty.Data.UnitOfWork.Interface;
using Applicanty.Services.Abstract;

namespace Applicanty.Services.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : class
    {

        protected IUnitOfWork _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public abstract void Create(TEntity entity);
        public abstract IEnumerable<TEntity> GetAll();
        public abstract ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        public abstract TEntity GetOne(int id);
        public abstract TEntity GetOne(Expression<Func<TEntity, bool>> predicate);
        public abstract void Update(TEntity entity);

    }
}