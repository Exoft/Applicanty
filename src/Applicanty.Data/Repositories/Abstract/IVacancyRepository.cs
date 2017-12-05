using Applicanty.Data.Entity;

namespace Applicanty.Data.Repositories
{ 
    public interface IVacancyRepository : IEntityBaseRepository<Vacancy, long>
    {
    }
}