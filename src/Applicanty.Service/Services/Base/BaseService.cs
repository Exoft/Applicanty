using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Applicanty.Data.UnitOfWork.Interface;
using Applicanty.Services.Abstract;
using AutoMapper;

namespace Applicanty.Services.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : class
    {

        protected IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public BaseService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public abstract void Create(TEntity entity);
        public abstract IEnumerable<TDto> GetAll<TDto>();
        public abstract ICollection<TDto> GetAll<TDto>(Expression<Func<TEntity, bool>> predicate);
        public abstract TDto GetOne<TDto>(int id);
        public abstract TDto GetOne<TDto>(Expression<Func<TEntity, bool>> predicate);
        public abstract void Update(TEntity entity);

    }
}