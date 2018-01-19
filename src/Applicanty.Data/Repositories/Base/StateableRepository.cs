using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Entities.Abstract;
using Applicanty.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace Applicanty.Data.Repositories
{
    internal class StateableRepository<TEntity> : EntityBaseRepository<TEntity>,
        IStateableRepository<TEntity>
        where TEntity : class, IEntity, IStateable
    {
        public StateableRepository(AtsDbContext context) : base(context)
        {
        }

        private void ChangeStatus(int id, string status)
        {
            TEntity obj = _dbSet.Find(id);

            switch (status)
            {
                case "ACTIVE" :
                    obj.StatusId = StatusType.Active;
                    break;

                case "ARCHIVED":
                    obj.StatusId = StatusType.Archived;
                    break;

                case "DELETED":
                    obj.StatusId = StatusType.Deleted;
                    break;
            }

            _entities.Entry(obj).State = EntityState.Modified;
        }

        public virtual void ChangeStatus(int[] arrayIds, string status)
        {
            for (int i = 0; i < arrayIds.Length; i++)
                ChangeStatus(arrayIds[i], status);
        }
    }
}
