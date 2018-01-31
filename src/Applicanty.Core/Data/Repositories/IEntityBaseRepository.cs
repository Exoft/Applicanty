﻿using Applicanty.Core.Entities.Abstract;
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
        int Count();
    }
}