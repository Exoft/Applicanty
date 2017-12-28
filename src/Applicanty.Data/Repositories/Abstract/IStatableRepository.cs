using Applicanty.Core.Abstract;
using System.Collections.Generic;

namespace Applicanty.Data.Repositories.Abstract
{
    public interface IStatableRepository<TEntity> : IEntityBaseRepository<TEntity>
       where TEntity : class, IEntity, IStateable
    {
        void Archive(int id);
        void Archive(ICollection<TEntity> list);
        void UnArchive(int id);
        void UnArchive(ICollection<TEntity> list);
    }
}
