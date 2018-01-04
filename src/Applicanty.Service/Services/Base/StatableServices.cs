using System.Collections.Generic;
using Applicanty.Core.Abstract;
using Applicanty.Data.UnitOfWork.Interface;
using Applicanty.Services.Abstract;
using AutoMapper;

namespace Applicanty.Services.Services
{
    public abstract class StateableService<TEntity> : BaseService<TEntity>, IStateableService<TEntity>
        where TEntity : class, IEntity, IStateable
    {

        public StateableService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {}

        public abstract void Archive(int id);
        public abstract void Archive(ICollection<TEntity> list);
        public abstract void UnArchive(int id);
        public abstract void UnArchive(ICollection<TEntity> list);
    }
}
