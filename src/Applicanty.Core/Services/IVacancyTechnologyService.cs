using Applicanty.Core.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Applicanty.Core.Services
{
    public interface IVacancyTechnologyService : IService<VacancyTechnology>
    {
        IEnumerable<VacancyTechnology> GetByVacancyId(int id);
        void Delete(Expression<System.Func<VacancyTechnology, bool>> predicate);
    }
}
