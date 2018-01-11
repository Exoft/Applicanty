using Applicanty.Core.Entities;
using Applicanty.Core.Data;
using Applicanty.Services.Abstract;
using AutoMapper;
using Applicanty.Core.Data.Repositories;

namespace Applicanty.Services.Services
{
    public class VacancyService : StateableService<Vacancy, IVacancyRepository>, IVacancyService
    {
        public VacancyService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        protected override IVacancyRepository InitRepository()
        {
            return UnitOfWork.VacancyRepository;
        }
    }
}
