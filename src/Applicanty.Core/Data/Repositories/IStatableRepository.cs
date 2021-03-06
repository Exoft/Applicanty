﻿using Applicanty.Core.Entities.Abstract;
using Applicanty.Core.Enums;
using System.Collections.Generic;

namespace Applicanty.Core.Data.Repositories
{
    public interface IStateableRepository<TEntity> : IEntityBaseRepository<TEntity>
       where TEntity : class, IEntity, IStateable
    {
        void ChangeStatus(int[] arrayIds, string status);
    }
}
