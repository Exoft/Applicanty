using Applicanty.Data.Entity;
using Applicanty.Data.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;


namespace Applicanty.Data.Services.Abstract
{
    public interface IStateableServices<TEntity, TKey> : IPimaryServices<TEntity, TKey>
        where TEntity : class 
        where TKey: IEquatable<TKey>
    {
        void Archive(TKey id);
        void Archive(ICollection<TEntity> list);
        void UnArchive(TKey id);
        void UnArchive(ICollection<TEntity> list);
    }
}
