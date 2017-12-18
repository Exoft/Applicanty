using System;

namespace Applicanty.Data.Services.Abstract
{
    public interface IPimaryServices<TEntity, TKey> : IEntityService<TEntity>
        where TEntity : class
        where TKey : IEquatable<TKey>
    {
        TEntity GetOne(TKey id);
    }
}
