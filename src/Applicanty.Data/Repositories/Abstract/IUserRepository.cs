using Applicanty.Data.Entity;

namespace Applicanty.Data.Repositories
{
    public interface IUserRepository : IEntityBaseRepository<User, long>
    {
        
    }
}