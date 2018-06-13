using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Entities;
using System;
using System.Linq;
using System.Security.Principal;

namespace Applicanty.Data.Repositories
{
    internal class CommentRepository : TrackableRepository<Comment>, ICommentRepository
    {
        public CommentRepository(AtsDbContext context, IPrincipal principal) : base(context, principal)
        { }

        public override Comment Update(Comment entity)
        {
            var comment = GetWithInclude(f => f.User)
                .FirstOrDefault( f => f.Id == entity.Id);

            entity.User = comment.User;

            return base.Update(entity);
        }

    }
}
