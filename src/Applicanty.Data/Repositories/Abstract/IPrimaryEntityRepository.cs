using Applicanty.Data.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applicanty.Data.Repositories.Abstract
{
    public interface IPrimaryEntityRepository<TEntity, TKey> : IEntityBaseRepository<TEntity, TKey>
        where TEntity : class, IPrimary<TKey>
        where TKey : IEquatable<TKey>
    {
        TEntity GetOne(TKey id);

    }
}
