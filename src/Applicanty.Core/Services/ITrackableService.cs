using Applicanty.Core.Entities.Abstract;

namespace Applicanty.Core.Services
{
    public interface ITrackableService<TEntity> : IStateableService<TEntity>
        where TEntity : class, IEntity, IStateable, ITrackable
    {
    }
}
