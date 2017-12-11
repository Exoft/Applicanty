using Applicanty.Data.Entity.Abstract;
using Applicanty.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applicanty.Data.Repositories
{
    public class PrimaryEntityRepository<TEntity, TKey> :EntityBaseRepository<TEntity,TKey>, IPrimaryEntityRepository<TEntity, TKey>
        where TEntity : class, IPrimary<TKey>
        where TKey : IEquatable<TKey>
    {
        public PrimaryEntityRepository(AtsDbContext context)
            : base(context)
        {
        }
        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public ICollection<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetOne(TKey id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
