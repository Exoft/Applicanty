using Applicant.Data.Entity;

namespace Applicant.Data.Repositories
{ 
    public interface IVacancyRepository : IRepository<Vacancy, long>
    {
    }
}