using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Applicanty.Core.Model;
using Applicanty.Data.UnitOfWork.Interface;
using Applicanty.Services.Abstract;

namespace Applicanty.Services.Services
{
    public class StatusService : BaseService<Status>, IStatusService
    {
        public StatusService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {}

        public override void Create(Status entity)
        {
            _unitOfWork.StatusRepository.Add(entity);
            _unitOfWork.Commit();
        }

        public override IEnumerable<Status> GetAll()
        {
            return _unitOfWork.StatusRepository.GetAll();
        }

        public override ICollection<Status> GetAll(Expression<Func<Status, bool>> predicate)
        {
            return _unitOfWork.StatusRepository.GetAll(predicate);
        }

        public override Status GetOne(int id)
        {
            return _unitOfWork.StatusRepository.GetOne(id);
        }

        public override Status GetOne(Expression<Func<Status, bool>> predicate)
        {
            return _unitOfWork.StatusRepository.GetOne(predicate);
        }

        public override void Update(Status entity)
        {
            _unitOfWork.StatusRepository.Update(entity);
            _unitOfWork.Commit();
        }
    }
}