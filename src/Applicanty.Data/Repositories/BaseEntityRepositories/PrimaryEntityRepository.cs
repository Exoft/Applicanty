using Applicanty.Data.Entity.Abstract;
using Applicanty.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        /// <summary>
        /// Returns a single object with a primary key of the provided id
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="id">The primary key of the object to fetch</param>
        /// <returns>A single object with the provided primary key or null</returns>
        public TEntity GetOne(TKey id)
        {
            return _dbSet.Find(id);
        }



        /// <summary>
        /// Returns a single object which matches the provided expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="predicate">A Linq expression filter to find a single result</param>
        /// <returns>A single object which matches the expression filter. 
        /// If more than one object is found or if zero are found, null is returned</returns>
        public TEntity GetOne(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate.Compile());
        }
    }
}
