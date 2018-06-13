using Applicanty.Core.Entities.Abstract;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Linq;
using Applicanty.Core.Data.Repositories;

namespace Applicanty.Data.Repositories
{
    internal class TrackableRepository<TEntity> : StateableRepository<TEntity>, ITrackableRepository<TEntity>
         where TEntity : class, IEntity, IStateable, ITrackable

    {
        private readonly ClaimsPrincipal _principal;

        public TrackableRepository(AtsDbContext context, IPrincipal principal)
            : base(context)
        {
            _principal = principal as ClaimsPrincipal;
        }

        public override TEntity Create(TEntity entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = GetUserId();

            entity.ModifiedAt = DateTime.Now;
            entity.ModifiedBy = GetUserId();

            return base.Create(entity);
        }

        public override TEntity Update(TEntity entity)
        {
            entity.ModifiedAt = DateTime.Now;
            entity.ModifiedBy = GetUserId();

            return base.Update(entity);
        }

        protected int GetUserId()
        {
            if (!_principal.Identity.IsAuthenticated)
            {
               throw new UnauthorizedAccessException();
            }

            var val = _principal.Claims.First(f => f.Type == "sub").Value;

            return Int32.Parse(val);
        }
    }
}