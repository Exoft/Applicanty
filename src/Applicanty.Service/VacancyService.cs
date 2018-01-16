using Applicanty.Core.Data;
using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Entities;
using Applicanty.Services.Abstract;
using AutoMapper;

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
