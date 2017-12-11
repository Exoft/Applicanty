using Applicanty.Data.Entity;
using System.Collections.Generic;

namespace Applicanty.Data.Services
{
    public interface IVacancyService :IEntityService<Vacancy>
    {
        ICollection<Vacancy> GetAll();
        Vacancy GetOne(long Id);
        void Archive(long id);
        void Archive(ICollection<Vacancy> list);
        void UnArchive(long id);
        void UnArchive(ICollection<Vacancy> list);
    }
}
