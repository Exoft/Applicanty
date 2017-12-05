using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Applicanty.Data;
using Microsoft.EntityFrameworkCore;

namespace Applicanty.Data.Repositories
{
    public class EntityBaseRepository<TEntity, TKey>: IEntityBaseRepository<TEntity, TKey> where TEntity : class
    {
        private AtsDbContext _entities;
        private readonly DbSet<TEntity> _dbSet;
        public EntityBaseRepository(AtsDbContext context)
        {
            _entities = context;
            _dbSet = context.Set<TEntity>();
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

        /// <summary>
        /// Returns a single object with a primary key of the provided id
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="id">The primary key of the object to fetch</param>
        /// <returns>A single object with the provided primary key or null</returns>
        public async Task<TEntity> GetOneAsync(TKey id)
        {
                return await _dbSet.FindAsync(id);
        }

        /// <summary>
        /// Gets a collection of all objects in the database
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <returns>An ICollection of every object in the database</returns>
        public ICollection<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking(). /*Where(f=>f.IsDeleted == false).*/ToList();
        }

        /// <summary>
        /// Returns a collection of objects which match the provided expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="predicate">A linq expression filter to find one or more results</param>
        /// <returns>An ICollection of object which match the expression filter</returns>
        public ICollection<TEntity> GetAll(Expression<System.Func<TEntity, bool>> predicate)
        {
                return _dbSet.AsNoTracking().AsEnumerable().Where(predicate.Compile()).ToList();
        }

        /// <summary>
        /// Gets a collection of all objects in the database
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <returns>An ICollection of every object in the database</returns>
        public async Task<IList<TEntity>> GetAllAsync()
        {
                return await _dbSet.AsNoTracking()./*Where(f=>f.IsDeleted == false).*/ToListAsync();
        }

        public async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
                return await _dbSet.AsNoTracking().Where(predicate)/*.Where(f => f.IsDeleted == false)*/.ToListAsync();
        }

        /// <summary>
        /// Inserts a single object to the database and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="entity">The object to insert</param>
        /// <returns>The resulting object including its primary key after the insert</returns>
        public void Add(TEntity entity)
        {
                _dbSet.Add(entity);
        }

        /// <summary>
        /// Inserts a single object to the database and commits the change
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="entity">The object to insert</param>
        /// <returns>The resulting object including its primary key after the insert</returns>
        //public  async Task AddAsync(TEntity entity)
        //{
        //    using (var db = new DataContextProvider())
        //    {
        //        _dbSet.Add(entity);
        //        await db.SaveChangesAsync();
        //    }
        //}

        /// <summary>
        /// Inserts a collection of objects into the database and commits the changes
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="entityList">An IEnumerable list of objects to insert</param>
        /// <returns>The IEnumerable resulting list of inserted objects including the primary keys</returns>
        public void AddAll(IEnumerable<TEntity> entityList)
        {
            _dbSet.AddRange(entityList);
        }

        /// <summary>
        /// Inserts a collection of objects into the database and commits the changes
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="entityList">An IEnumerable list of objects to insert</param>
        /// <returns>The IEnumerable resulting list of inserted objects including the primary keys</returns>
        public void AddAllAsync(IEnumerable<TEntity> entityList)
        {
                _dbSet.AddRange(entityList);
        }

        public  void Update(TEntity entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Gets the count of the number of objects in the databse
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <returns>The count of the number of objects</returns>
        public int Count()
        {
                return _dbSet.Count();
        }

        public  int Count(Expression<System.Func<TEntity, bool>> predicate)
        {
                return _dbSet.Count(predicate.Compile());
        }

        public  async Task<int> CountAsync(Expression<System.Func<TEntity, bool>> predicate)
        {
                return await _dbSet.CountAsync(predicate);
        }

        /// <summary>
        /// Gets the count of the number of objects in the databse
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <returns>The count of the number of objects</returns>
        public async Task<int> CountAsync()
        {
                return await _dbSet.CountAsync();
        }
    }
}