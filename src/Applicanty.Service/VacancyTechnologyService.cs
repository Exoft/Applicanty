using Applicanty.Core.Data;
using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Entities;
using Applicanty.Core.Services;
using AutoMapper;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Applicanty.Services.Services
{
    public class VacancyTechnologyService : BaseService<VacancyTechnology, IVacancyTechnologyRepositort>, IVacancyTechnologyService
    {
        public VacancyTechnologyService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }

        protected override IVacancyTechnologyRepositort InitRepository() =>
            UnitOfWork.VacancyTechnologyRepositort;

        public IEnumerable<VacancyTechnology> GetByVacancyId(int id)
        {
            return Repository.GetAll(item => item.VacancyId == id);
        }

        public void Delete(Expression<System.Func<VacancyTechnology, bool>> predicate)
        {
            Repository.Delete(predicate);
            UnitOfWork.Commit();
        }
    }
}