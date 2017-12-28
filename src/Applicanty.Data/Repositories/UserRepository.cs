using Applicanty.Core.Model;
using Applicanty.Data.Repositories.Abstract;

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
