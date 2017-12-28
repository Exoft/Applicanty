using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Applicanty.Services.Abstract
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        TEntity GetOne(int id);
        void Create(TEntity entity);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
        TEntity GetOne(Expression<Func<TEntity, bool>> predicate);
        ICollection<TEntity> GetAll(Expression<System.Func<TEntity, bool>> predicate);
    }
}
