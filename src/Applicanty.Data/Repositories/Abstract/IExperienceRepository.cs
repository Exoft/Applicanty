using Applicanty.Data.Entity;
using Applicanty.Data.Repositories.Abstract;

namespace Applicanty.Data.Repositories
{ 
    public interface IExperienceRepository : IPrimaryEntityRepository<Experience, int>
    {
    }
}