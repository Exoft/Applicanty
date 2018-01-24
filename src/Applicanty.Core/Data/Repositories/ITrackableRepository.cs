using Applicanty.Core.Entities.Abstract;

namespace Applicanty.Core.Data.Repositories
{
    public interface ITrackableRepository<TEntity> : IStateableRepository<TEntity>
        where TEntity : class, IEntity, IStateable, ITrackable
    {
    }
}
