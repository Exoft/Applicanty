using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Applicanty.Core.Model;
using Applicanty.Data.UnitOfWork.Interface;
using Applicanty.Services.Abstract;

namespace Applicanty.Services.Services
{
    public class VacancyService : StateableService<Vacancy>, IVacancyService
    {
        public VacancyService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { }

        public override void Archive(int id)
        {
            _unitOfWork.VacancyRepository.Archive(id);
            _unitOfWork.Commit();
        }

        public override void Archive(ICollection<Vacancy> list)
        {
            _unitOfWork.VacancyRepository.Archive(list);
            _unitOfWork.Commit();
        }

        public override void Create(Vacancy entity)
        {
            _unitOfWork.VacancyRepository.Add(entity);
            _unitOfWork.Commit();
        }

        public override IEnumerable<Vacancy> GetAll()
        {
            return _unitOfWork.VacancyRepository.GetAll();
        }

        public override ICollection<Vacancy> GetAll(Expression<Func<Vacancy, bool>> predicate)
        {
            return _unitOfWork.VacancyRepository.GetAll(predicate);
        }

        public override Vacancy GetOne(int id)
        {
            return _unitOfWork.VacancyRepository.GetOne(id);
        }

        public override Vacancy GetOne(Expression<Func<Vacancy, bool>> predicate)
        {
            return _unitOfWork.VacancyRepository.GetOne(predicate);
        }

        public override void UnArchive(int id)
        {
            _unitOfWork.VacancyRepository.UnArchive(id);
            _unitOfWork.Commit();
        }

        public override void UnArchive(ICollection<Vacancy> list)
        {
            _unitOfWork.VacancyRepository.UnArchive(list);
            _unitOfWork.Commit();
        }

        public override void Update(Vacancy entity)
        {
            _unitOfWork.VacancyRepository.Update(entity);
            _unitOfWork.Commit();
        }
    }
}
