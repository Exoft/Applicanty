using Applicanty.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Applicanty.Core.Data.Repositories
{
    public interface IEntityBaseRepository<TEntity> where TEntity : class
    {
        TEntity GetOne(int id);
        TEntity GetOne(Expression<Func<TEntity, bool>> predicate);
        ICollection<TEntity> GetAll();
        ICollection<TEntity> GetAll(Expression<System.Func<TEntity, bool>> predicate);
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity GetWithInclude(int id, params Expression<Func<TEntity, object>>[] includeProperties);
        int Count();
    }
}