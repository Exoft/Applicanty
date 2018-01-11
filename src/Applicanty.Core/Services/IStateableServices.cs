﻿using Applicanty.Core.Entities.Abstract;
using System.Collections.Generic;

namespace Applicanty.Services.Abstract
{
    public interface IStateableService<TEntity> : IService<TEntity>
        where TEntity : class, IEntity, IStateable
    {
        void Archive(int id);
        void Archive(ICollection<TEntity> list);
        void UnArchive(int id);
        void UnArchive(ICollection<TEntity> list);
    }
}