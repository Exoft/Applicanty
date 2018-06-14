using Applicanty.Core.Data;
using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Entities.Abstract;
using AutoMapper;

namespace Applicanty.Services.Services
{
    public abstract class TrackableService<TEntity, TRepository> : StateableService<TEntity, TRepository>
        where TEntity : class, IEntity, IStateable, ITrackable
        where TRepository : ITrackableRepository<TEntity>
    {
        public TrackableService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
