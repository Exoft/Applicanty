using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Applicanty.Data.Repositories
{
    internal class EntityBaseRepository<TEntity> : IEntityBaseRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected AtsDbContext _entities;
        protected readonly DbSet<TEntity> _dbSet;

        public EntityBaseRepository(AtsDbContext context)
        {
            _entities = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual TEntity GetOne(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual TEntity GetOne(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate.Compile());
        }

        public virtual ICollection<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public virtual ICollection<TEntity> GetAll(Expression<System.Func<TEntity, bool>> predicate)
        {
            return _dbSet.AsNoTracking().AsEnumerable().Where(predicate.Compile()).ToList();
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void AddAll(IEnumerable<TEntity> entityList)
        {
            _dbSet.AddRange(entityList);
        }

        public virtual TEntity Update(TEntity entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public virtual int Count()
        {
            return _dbSet.Count();
        }

        public virtual int Count(Expression<System.Func<TEntity, bool>> predicate)
        {
            return _dbSet.Count(predicate.Compile());
        }
    }
}