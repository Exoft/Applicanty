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
    public class ExperienceService : BaseService<Experience>, IExperienceService
    {
        public ExperienceService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override void Create(Experience entity)
        {
            _unitOfWork.ExperienceRepository.Add(entity);
            _unitOfWork.Commit();
        }

        public override IEnumerable<ExperienceDTO> GetAll<ExperienceDTO>()
        {
            var entity = _unitOfWork.ExperienceRepository.GetAll();
            return _mapper.Map<IEnumerable<Experience>, IEnumerable<ExperienceDTO>>(entity);
        }

        public override ICollection<ExperienceDTO> GetAll<ExperienceDTO>(Expression<Func<Experience, bool>> predicate)
        {
            var entity = _unitOfWork.ExperienceRepository.GetAll(predicate);
            return _mapper.Map<ICollection<Experience>, ICollection<ExperienceDTO>>(entity);

        }

        public override ExperienceDTO GetOne<ExperienceDTO>(int id)
        {
            var entity = _unitOfWork.ExperienceRepository.GetOne(id);
            return _mapper.Map<Experience, ExperienceDTO>(entity);
        }

        public override ExperienceDTO GetOne<ExperienceDTO>(Expression<Func<Experience, bool>> predicate)
        {
            var entity = _unitOfWork.ExperienceRepository.GetOne(predicate);
            return _mapper.Map<Experience, ExperienceDTO>(entity);

        }

        public override void Update(Experience entity)
        {
            _unitOfWork.ExperienceRepository.Update(entity);
            _unitOfWork.Commit();
        }
    }
}
