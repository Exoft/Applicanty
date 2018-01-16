using Applicanty.Core.Entities.Abstract;
using Applicanty.Core.Enums;

namespace Applicanty.Services.Abstract
{
    public interface IStateableService<TEntity> : IService<TEntity>
        where TEntity : class, IEntity, IStateable
    {
        void ChangeStatus(int[] arrayIds, StatusType status);
    }
}
