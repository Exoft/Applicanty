using System.Collections.Generic;

namespace Applicanty.Data.Repositories
{ 
    public interface IEntityBaseRepository<TRespository, TKey> where TRespository : class
    {
        TRespository GetOne(TKey id);
        ICollection<TRespository> GetAll();
        void Add(TRespository entity);
        void Update(TRespository entity);
        int Count();
    }
}