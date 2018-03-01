using Applicanty.Core.Data;
using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Entities.Abstract;
using Applicanty.Core.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Applicanty.Services.Services
{
    public abstract class BaseService<TEntity, TRepository> : IService<TEntity>
        where TEntity : class, IEntity
        where TRepository : IEntityBaseRepository<TEntity>
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

        public IEnumerable<TDto> GetWithInclude<TDto>(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var entities = Repository.GetWithInclude(includeProperties);

            return _mapper.Map<IEnumerable<TEntity>, IEnumerable<TDto>>(entities);
        }

        public TDto GetWithInclude<TDto>(int id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var entity = Repository.GetWithInclude(id, includeProperties);
            return _mapper.Map<TEntity, TDto>(entity);
        }

        public virtual TDto Create<TDto>(TDto dto) where TDto : class
        {
            var entity = _mapper.Map<TDto, TEntity>(dto);

            var createdEntity = Repository.Create(entity);
            _unitOfWork.Commit();

            return _mapper.Map<TEntity, TDto>(createdEntity);
        }

        public virtual TDto Update<TDto>(TDto dto)
        {
            var entity = _mapper.Map<TDto, TEntity>(dto);

            var updatedEntity = Repository.Update(entity);
            _unitOfWork.Commit();

            return _mapper.Map<TEntity, TDto>(updatedEntity);
        }

        public virtual void Delete(int id)
        {
            Repository.Delete(item=>item.Id == id);
            _unitOfWork.Commit();
        }
    }
}