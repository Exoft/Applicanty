using System.Collections.Generic;

namespace Applicanty.Data.Services
{
    public interface IEntityService<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
    }
}
