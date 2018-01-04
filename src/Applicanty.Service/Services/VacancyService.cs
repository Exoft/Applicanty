using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Applicanty.Core.Model;
using Applicanty.Data.UnitOfWork.Interface;
using Applicanty.DTO.DtoModel;
using Applicanty.Services.Abstract;
using AutoMapper;

namespace Applicanty.Services.Services
{
    public class VacancyService : StateableService<Vacancy>, IVacancyService
    {
        public VacancyService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
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

        public override IEnumerable<VacancyDTO> GetAll<VacancyDTO>()
        {
            var entity = _unitOfWork.VacancyRepository.GetAll();
            return _mapper.Map<IEnumerable<Vacancy>, IEnumerable<VacancyDTO>>(entity);
        }

        public override ICollection<VacancyDTO> GetAll<VacancyDTO>(Expression<Func<Vacancy, bool>> predicate)
        {
            var entity = _unitOfWork.VacancyRepository.GetAll(predicate);
            return _mapper.Map<ICollection<Vacancy>, ICollection<VacancyDTO>>(entity);
        }

        public override VacancyDetailDTO GetOne<VacancyDetailDTO>(int id)
        {
            var entity = _unitOfWork.VacancyRepository.GetOne(id);
            return _mapper.Map<Vacancy, VacancyDetailDTO>(entity);
        }

        public override VacancyDetailDTO GetOne<VacancyDetailDTO>(Expression<Func<Vacancy, bool>> predicate)
        {
            var entity = _unitOfWork.VacancyRepository.GetOne(predicate);
            return _mapper.Map<Vacancy, VacancyDetailDTO>(entity);
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
