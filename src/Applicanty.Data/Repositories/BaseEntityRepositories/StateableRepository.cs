using Applicanty.Data.Entity;
using Applicanty.Data.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applicanty.Data.Repositories
{
    public class StateableRepository<TEntity, TKey> : PrimaryEntityRepository<TEntity, TKey>
        where TEntity : class, IPrimary<TKey>, IStatable
        where TKey : IEquatable<TKey>
    {
        public StateableRepository(AtsDbContext context) : base(context)
        {
        }

        public void Archive(TKey id)
        {
            TEntity obj = _dbSet.Find(id);
            obj.IsArchived = true;
            _entities.Entry(obj).State = EntityState.Modified;
        }

        public void Archive(ICollection<TEntity> list)
        {
            foreach (var item in list)
            {
                item.IsArchived = true;
                _entities.Entry(item).State = EntityState.Modified;
            }
        }

        public void UnArchive(TKey id)
        {
            TEntity obj = _dbSet.Find(id);
            obj.IsArchived = false;
            _entities.Entry(obj).State = EntityState.Modified;

        }

        public void UnArchive(ICollection<TEntity> list)
        {
            foreach (var item in list)
            {
                item.IsArchived = false;
                _entities.Entry(item).State = EntityState.Modified;
            }
        }
    }
}
