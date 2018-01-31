using Applicanty.Core.Data;
using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Entities;
using Applicanty.Core.Services;
using AutoMapper;

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
    }
}
