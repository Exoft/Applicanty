using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Applicanty.Core.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        TDto GetOne<TDto>(int id);
        TDto Create<TDto>(TDto entity) where TDto : class;
        IEnumerable<TDto> GetAll<TDto>();
        TDto Update<TDto>(TDto entity);
        TDto GetOne<TDto>(Expression<Func<TEntity, bool>> predicate);
        ICollection<TDto> GetAll<TDto>(Expression<System.Func<TEntity, bool>> predicate);
        IEnumerable<TDto> GetWithInclude<TDto>(params Expression<Func<TEntity, object>>[] includeProperties);
        TDto GetWithInclude<TDto>(int id, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}