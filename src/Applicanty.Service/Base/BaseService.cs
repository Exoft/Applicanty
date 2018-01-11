using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Data;
using Applicanty.Services.Abstract;
using AutoMapper;
using Applicanty.Core.Entities.Abstract;

namespace Applicanty.Services.Services
{
    public abstract class BaseService<TEntity, TRepository> : IService<TEntity>
        where TEntity : class, IEntity
        where TRepository: IEntityBaseRepository<TEntity>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly TRepository _repository;

        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = InitRepository();
        }

        protected IMapper Mapper => _mapper;
        protected IUnitOfWork UnitOfWork => _unitOfWork;
        protected virtual TRepository Repository => _repository;

        protected abstract TRepository InitRepository();

        public virtual void Create(TEntity entity)
        {
            Repository.Add(entity);
            _unitOfWork.Commit();
        }

        public virtual IEnumerable<TDto> GetAll<TDto>()
        {
            var entities = Repository.GetAll();
            return _mapper.Map<ICollection<TEntity>, ICollection<TDto>>(entities);
        }

        public virtual ICollection<TDto> GetAll<TDto>(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = Repository.GetAll(predicate);
            return _mapper.Map<ICollection<TEntity>, ICollection<TDto>>(entities);
        }

        public virtual TDto GetOne<TDto>(int id)
        {
            var entity = Repository.GetOne(id);
            return _mapper.Map<TEntity, TDto>(entity);
        }

        public virtual TDto GetOne<TDto>(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = Repository.GetOne(predicate);
            return _mapper.Map<TEntity, TDto>(entity);
        }

        public virtual void Update(TEntity entity)
        {
            Repository.Update(entity);
            _unitOfWork.Commit();
        }
    }
}