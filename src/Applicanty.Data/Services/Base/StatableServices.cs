using System;
using System.Collections.Generic;
using System.Text;
using Applicanty.Data.Entity;
using Applicanty.Data.Entity.Abstract;
using Applicanty.Data.Repositories;
using Applicanty.Data.Repositories.Abstract;
using Applicanty.Data.Services.Abstract;
using Applicanty.Data.UnitOfWork.Interface;

namespace Applicanty.Data.Services.Base
{
    public class StateableServices<TEntity, TKey> : PrimaryServices<TEntity, TKey>, IStateableServices<TEntity, TKey>
        where TEntity : class, IPrimary<TKey>, IStateable
        where TKey : IEquatable<TKey>
    {
        protected IStatableRepository<TEntity, TKey> _repository;
     
        public StateableServices(IUnitOfWork unitOfWork, IStatableRepository<TEntity, TKey> repository) : base(unitOfWork, repository)
        {
            _repository = repository;
        }

        public void Archive(TKey id)
        {
            _repository.Archive(id);
            _unitOfWork.Commit();
        }

        public void Archive(ICollection<TEntity> list)
        {
            _repository.Archive(list);
            _unitOfWork.Commit();
        }

        public void UnArchive(TKey id)
        {
            _repository.UnArchive(id);
            _unitOfWork.Commit();
        }

        public void UnArchive(ICollection<TEntity> list)
        {
            _repository.UnArchive(list);
            _unitOfWork.Commit();
        }
    }
}
