using Applicanty.Core.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Applicanty.Data.Repositories
{
    internal class EntityBaseRepository<TEntity> : IEntityBaseRepository<TEntity>
        where TEntity : class
    {
        protected AtsDbContext _entities;
        protected readonly DbSet<TEntity> _dbSet;

        public EntityBaseRepository(AtsDbContext context)
        {
            _entities = context;
            _dbSet = context.Set<TEntity>();
        }

        public TEntity GetOne(int id)
        {
            return _dbSet.Find(id);
        }

        public TEntity GetOne(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate.Compile());
        }

        public ICollection<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public ICollection<TEntity> GetAll(Expression<System.Func<TEntity, bool>> predicate)
        {
            return _dbSet.AsNoTracking().AsEnumerable().Where(predicate.Compile()).ToList();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void AddAll(IEnumerable<TEntity> entityList)
        {
            _dbSet.AddRange(entityList);
        }

        public void Update(TEntity entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public int Count()
        {
            return _dbSet.Count();
        }

        public int Count(Expression<System.Func<TEntity, bool>> predicate)
        {
            return _dbSet.Count(predicate.Compile());
        }
    }
}