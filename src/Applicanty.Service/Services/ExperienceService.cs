using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Applicanty.Core.Model;
using Applicanty.Data.UnitOfWork.Interface;
using Applicanty.Services.Abstract;

namespace Applicanty.Services.Services
{
    public class ExperienceService : BaseService<Experience>, IExperienceService
    {
        public ExperienceService(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {}

        public override void Create(Experience entity)
        {
            _unitOfWork.ExperienceRepository.Add(entity);
            _unitOfWork.Commit();
        }

        public override IEnumerable<Experience> GetAll()
        {
            return _unitOfWork.ExperienceRepository.GetAll();
        }

        public override ICollection<Experience> GetAll(Expression<Func<Experience, bool>> predicate)
        {
            return _unitOfWork.ExperienceRepository.GetAll(predicate);
        }

        public override Experience GetOne(int id)
        {
            return _unitOfWork.ExperienceRepository.GetOne(id);
        }

        public override Experience GetOne(Expression<Func<Experience, bool>> predicate)
        {
            return _unitOfWork.ExperienceRepository.GetOne(predicate);
        }

        public override void Update(Experience entity)
        {
             _unitOfWork.ExperienceRepository.Update(entity);
            _unitOfWork.Commit();
        }
    }
}
