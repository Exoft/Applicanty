using Applicanty.Data.Entity;
using Applicanty.Data.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applicanty.Data.Repositories.Abstract
{
    public interface IStatableRepository<TEntity, TKey> : IPrimaryEntityRepository<TEntity, TKey>
        where TEntity : class, IPrimary<TKey>, IStatable
        where TKey : IEquatable<TKey>
    {
        void Archive(TKey id);
        void Archive(ICollection<TEntity> list);
        void UnArchive(TKey id);
        void UnArchive(ICollection<TEntity> list);
    }
}
