using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Applicanty.Data.Repositories
{
    internal class StateableRepository<TEntity> : EntityBaseRepository<TEntity>,
        IStateableRepository<TEntity>
        where TEntity : class, IEntity, IStateable
    {
        public StateableRepository(AtsDbContext context) : base(context)
        {
        }

        public virtual void Archive(int id)
        {
            TEntity obj = _dbSet.Find(id);
            obj.IsArchived = true;
            _entities.Entry(obj).State = EntityState.Modified;
        }

        public virtual void Archive(ICollection<TEntity> list)
        {
            foreach (var item in list)
            {
                item.IsArchived = true;
                _entities.Entry(item).State = EntityState.Modified;
            }
        }

        public virtual void UnArchive(int id)
        {
            TEntity obj = _dbSet.Find(id);
            obj.IsArchived = false;
            _entities.Entry(obj).State = EntityState.Modified;

        }

        public virtual void UnArchive(ICollection<TEntity> list)
        {
            foreach (var item in list)
            {
                item.IsArchived = false;
                _entities.Entry(item).State = EntityState.Modified;
            }
        }
    }
}
