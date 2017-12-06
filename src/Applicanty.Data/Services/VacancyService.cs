using Applicanty.Data.Entity;
using Applicanty.Data.Repositories;
using Applicanty.Data.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applicanty.Data.Services
{
    public class VacancyService : EntityService<Vacancy, long>, IVacancyService
    {
        IUnitOfWork _unitOfWork;
        IVacancyRepository _vacancyRepository;
        public VacancyService(IUnitOfWork unitOfWork, IVacancyRepository vacancyRepository)
            :base(unitOfWork, vacancyRepository)
        {
            _unitOfWork = unitOfWork;
            _vacancyRepository = vacancyRepository;
        }
        public Vacancy GetById(long Id)
        {
            return _vacancyRepository.GetOne(Id);
        }
    }
}
