using System.Collections.Generic;

namespace Applicanty.Data.Repositories
{ 
    public interface IEntityBaseRepository<TEntity, TKey> where TEntity : class
    {
        ICollection<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        int Count();
    }
}