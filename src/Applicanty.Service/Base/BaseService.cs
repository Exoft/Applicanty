using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Data;
using Applicanty.Services.Abstract;
using AutoMapper;

namespace Applicanty.Services.Services
{
    public abstract class BaseService<TEntity> : IService<TEntity>
        where TEntity : class
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEntityBaseRepository<TEntity> _repository;

        public BaseService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        
            _repository = InitRepository();
        }

        protected IMapper Mapper => _mapper;
        protected IUnitOfWork UnitOfWork => _unitOfWork;
        protected IEntityBaseRepository<TEntity> Repository => _repository;

        protected abstract IEntityBaseRepository<TEntity> InitRepository();

        public abstract void Create(TEntity entity);
        public abstract IEnumerable<TDto> GetAll<TDto>();
        public abstract ICollection<TDto> GetAll<TDto>(Expression<Func<TEntity, bool>> predicate);
        public abstract TDto GetOne<TDto>(int id);
        public abstract TDto GetOne<TDto>(Expression<Func<TEntity, bool>> predicate);
        public abstract void Update(TEntity entity);

    }
}