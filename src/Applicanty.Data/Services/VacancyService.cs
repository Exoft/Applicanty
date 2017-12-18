using Applicanty.Data.Entity;
using Applicanty.Data.Repositories;
using Applicanty.Data.UnitOfWork.Interface;
using System.Collections.Generic;
using Applicanty.Data.Services.Base;

namespace Applicanty.Data.Services
{
    public class VacancyService : StateableServices<Vacancy, long>, IVacancyService
    {
        IUnitOfWork _unitOfWork;
        IVacancyRepository _vacancyRepository;
        public VacancyService(IUnitOfWork unitOfWork, IVacancyRepository vacancyRepository)
            :base(unitOfWork, vacancyRepository)
        {
            _unitOfWork = unitOfWork;
            _vacancyRepository = vacancyRepository;
        }
       

       
    }
}
