using Applicanty.Data.Entity;

namespace Applicanty.Data.Services
{
    interface IVacancyService :IEntityService<Vacancy>
    {
        Vacancy GetById(long Id);
    }
}
