using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Entities.Abstract;
using Applicanty.Core.Enums;
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

        public virtual void ChangeStatus(int id, StatusType status)
        {
            TEntity obj = _dbSet.Find(id);
            obj.StatusId = status;
            _entities.Entry(obj).State = EntityState.Modified;
        }

        public virtual void ChangeStatus(int[] arrayIds, StatusType status)
        {
            for (int i = 0; i < arrayIds.Length; i++)
            {
                ChangeStatus(arrayIds[i], status);
            }
        }
    }
}
