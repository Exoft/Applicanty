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
        public Vacancy GetOne(long Id)
        {
            return _vacancyRepository.GetOne(Id);
        }

        public ICollection<Vacancy> GetAll()
        {
            return _vacancyRepository.GetAll();
        }

        public void Create(Vacancy obj)
        {
            _vacancyRepository.Add(obj);
            _unitOfWork.Commit();
        }

        public void Update(Vacancy obj)
        {
            _vacancyRepository.Update(obj);
            _unitOfWork.Commit();
        }

        public void Archive(long id)
        {
            _vacancyRepository.Archive(id);
            _unitOfWork.Commit();
        }

        public void Archive(ICollection<Vacancy> list)
        {
            _vacancyRepository.Archive(list);
            _unitOfWork.Commit();
        }

        public void UnArchive(long id)
        {
            _vacancyRepository.UnArchive(id);
            _unitOfWork.Commit();
        }

        public void UnArchive(ICollection<Vacancy> list)
        {
            _vacancyRepository.UnArchive(list);
            _unitOfWork.Commit();
        }
    }
}
