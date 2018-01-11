using Applicanty.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Applicanty.Services.Abstract
{
    public interface IService<TEntity> where TEntity : class, IEntity
    {
        TDto GetOne<TDto>(int id);
        void Create(TEntity entity);
        IEnumerable<TDto> GetAll<TDto>();
        void Update(TEntity entity);
        TDto GetOne<TDto>(Expression<Func<TEntity, bool>> predicate);
        ICollection<TDto> GetAll<TDto>(Expression<System.Func<TEntity, bool>> predicate);
    }
}
