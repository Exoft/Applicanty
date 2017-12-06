using Applicanty.Data.Entity;

namespace Applicanty.Data.Services
{
    public interface IVacancyService :IEntityService<Vacancy>
    {
        Vacancy GetById(long Id);
    }
}
