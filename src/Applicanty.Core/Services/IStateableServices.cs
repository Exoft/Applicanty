using Applicanty.Core.Entities.Abstract;

namespace Applicanty.Core.Services
{
    public interface IStateableService<TEntity> : IService<TEntity>
        where TEntity : class, IEntity, IStateable
    {
        void ChangeStatus(int[] arrayIds, string status);
    }
}
