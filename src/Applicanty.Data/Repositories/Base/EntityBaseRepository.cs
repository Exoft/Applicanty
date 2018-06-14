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

        public virtual TEntity Create(TEntity entity)
        {
            _dbSet.Add(entity);
            return entity;
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
        public void UpdateManyToMany<T, TKey>(IEnumerable<T> currentItems, IEnumerable<T> newItems, Func<T, TKey> getKey)
            where T : class
        {
            foreach (var item in Except(currentItems, newItems, getKey))
                _entities.Entry(item).State = EntityState.Deleted;

            foreach (var item in Except(newItems, currentItems, getKey))
                _entities.Entry(item).State = EntityState.Added;

        }

        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            _entities.RemoveRange(GetAll(predicate));
        }

        public virtual int Count()
        {
            return _dbSet.Count();
        }

        public virtual int Count(Expression<System.Func<TEntity, bool>> predicate)
        {
            return _dbSet.Count(predicate.Compile());
        }

        public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public TEntity GetWithInclude(int id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.FirstOrDefault(item => item.Id == id);
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        private IEnumerable<T> Except<T, TKey>(IEnumerable<T> items, IEnumerable<T> other, Func<T, TKey> getKeyFunc)
        {
            return items
                .GroupJoin(other, getKeyFunc, getKeyFunc, (item, tempItems) => new { item, tempItems })
                .SelectMany(t => t.tempItems.DefaultIfEmpty(), (t, temp) => new { t, temp })
                .Where(t => ReferenceEquals(null, t.temp) || t.temp.Equals(default(T)))
                .Select(t => t.t.item);
        }
    }
}