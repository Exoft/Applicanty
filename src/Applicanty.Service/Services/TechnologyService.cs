using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Applicanty.Core.Model;
using Applicanty.Data.UnitOfWork.Interface;
using Applicanty.Services.Abstract;

namespace Applicanty.Services.Services
{
    public class TechnologyService : BaseService<Technology>, ITechnologyService
    {
        public TechnologyService(IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {}

        public override void Create(Technology entity)
        {
            _unitOfWork.TechnologyRepository.Add(entity);
            _unitOfWork.Commit();
        }

        public override IEnumerable<Technology> GetAll()
        {
            return _unitOfWork.TechnologyRepository.GetAll();
        }

        public override ICollection<Technology> GetAll(Expression<Func<Technology, bool>> predicate)
        {
            return _unitOfWork.TechnologyRepository.GetAll(predicate);
        }

        public override Technology GetOne(int id)
        {
            return _unitOfWork.TechnologyRepository.GetOne(id);
        }

        public override Technology GetOne(Expression<Func<Technology, bool>> predicate)
        {
            return _unitOfWork.TechnologyRepository.GetOne(predicate);
        }

        public override void Update(Technology entity)
        {
            _unitOfWork.TechnologyRepository.Update(entity);
            _unitOfWork.Commit();
        }
    }
}
