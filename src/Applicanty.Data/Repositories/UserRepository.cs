using Applicanty.Core.Entities;
using Applicanty.Core.Data.Repositories;

namespace Applicanty.Data.Repositories
{
    internal class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        public UserRepository(AtsDbContext context) 
            : base(context)
        {
        }
    }
}
