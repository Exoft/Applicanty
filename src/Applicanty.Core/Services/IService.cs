using Applicanty.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Applicanty.Core.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        TDto GetOne<TDto>(int id);
        void Create<TDto>(TDto entity);
        IEnumerable<TDto> GetAll<TDto>();
        TDto Update<TDto>(TDto entity);
        TDto GetOne<TDto>(Expression<Func<TEntity, bool>> predicate);
        ICollection<TDto> GetAll<TDto>(Expression<System.Func<TEntity, bool>> predicate);
    }
}
