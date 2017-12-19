using Applicanty.Data.Entity;

namespace Applicanty.Data.Repositories
{
    public class UserRepository : PrimaryEntityRepository<User, long>, IUserRepository
    {
        public UserRepository(AtsDbContext context) 
            : base(context)
        {
        }
    }
}
