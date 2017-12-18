using System;
using System.Collections.Generic;
using System.Text;
using Applicanty.Data.Entity.Abstract;
using Applicanty.Data.Repositories;
using Applicanty.Data.Repositories.Abstract;
using Applicanty.Data.Services.Abstract;
using Applicanty.Data.UnitOfWork.Interface;

namespace Applicanty.Data.Services
{
    public class PrimaryServices<TEntity, TKey> : EntityService<TEntity, TKey>, IPimaryServices<TEntity, TKey>
        where TEntity : class, IPrimary<TKey>
        where TKey : IEquatable<TKey>
    {

        protected new IPrimaryEntityRepository<TEntity, TKey> _repository;

        public PrimaryServices(IUnitOfWork unitOfWork, IPrimaryEntityRepository<TEntity, TKey> repository)
            :base(unitOfWork, repository)
        {
            _repository = repository;
        }

        public virtual TEntity GetOne(TKey id)
        {
            return _repository.GetOne(id);
        }
    }
}
