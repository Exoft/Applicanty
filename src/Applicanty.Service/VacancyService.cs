using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Applicanty.Core.Entities;
using Applicanty.Core.Data;
using Applicanty.Services.Abstract;
using AutoMapper;
using Applicanty.Core.Data.Repositories;

namespace Applicanty.Services.Services
{
    public class VacancyService : StateableService<Vacancy>, IVacancyService
    {
        public VacancyService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override void Archive(int id)
        {
            UnitOfWork.VacancyRepository.Archive(id);
            UnitOfWork.Commit();
        }

        public override void Archive(ICollection<Vacancy> list)
        {
            UnitOfWork.VacancyRepository.Archive(list);
            UnitOfWork.Commit();
        }

        public override void Create(Vacancy entity)
        {
            UnitOfWork.VacancyRepository.Add(entity);
            UnitOfWork.Commit();
        }

        public override IEnumerable<VacancyDTO> GetAll<VacancyDTO>()
        {
            var entity = UnitOfWork.VacancyRepository.GetAll();
            return Mapper.Map<IEnumerable<Vacancy>, IEnumerable<VacancyDTO>>(entity);
        }

        public override ICollection<VacancyDTO> GetAll<VacancyDTO>(Expression<Func<Vacancy, bool>> predicate)
        {
            var entity = UnitOfWork.VacancyRepository.GetAll(predicate);
            return Mapper.Map<ICollection<Vacancy>, ICollection<VacancyDTO>>(entity);
        }

        public override VacancyDetailDTO GetOne<VacancyDetailDTO>(int id)
        {
            var entity = UnitOfWork.VacancyRepository.GetOne(id);
            return Mapper.Map<Vacancy, VacancyDetailDTO>(entity);
        }

        public override VacancyDetailDTO GetOne<VacancyDetailDTO>(Expression<Func<Vacancy, bool>> predicate)
        {
            var entity = UnitOfWork.VacancyRepository.GetOne(predicate);
            return Mapper.Map<Vacancy, VacancyDetailDTO>(entity);
        }

        public override void UnArchive(int id)
        {
            UnitOfWork.VacancyRepository.UnArchive(id);
            UnitOfWork.Commit();
        }

        public override void UnArchive(ICollection<Vacancy> list)
        {
            UnitOfWork.VacancyRepository.UnArchive(list);
            UnitOfWork.Commit();
        }

        public override void Update(Vacancy entity)
        {
            UnitOfWork.VacancyRepository.Update(entity);
            UnitOfWork.Commit();
        }

        protected override IEntityBaseRepository<Vacancy> InitRepository()
        {
            throw new NotImplementedException();
        }
    }
}
