using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Applicanty.Core.Model;
using Applicanty.Data.UnitOfWork.Interface;
using Applicanty.Services.Abstract;
using AutoMapper;

namespace Applicanty.Services.Services
{
    public class StatusService : BaseService<Status>, IStatusService
    {
        public StatusService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {}

        public override void Create(Status entity)
        {
            _unitOfWork.StatusRepository.Add(entity);
            _unitOfWork.Commit();
        }

        public override IEnumerable<StatusDTO> GetAll<StatusDTO>()
        {
            var entity = _unitOfWork.StatusRepository.GetAll();
            return _mapper.Map<IEnumerable<Status>,IEnumerable<StatusDTO>>(entity);
        }

        public override ICollection<StatusDTO> GetAll<StatusDTO>(Expression<Func<Status, bool>> predicate)
        {
            var entity = _unitOfWork.StatusRepository.GetAll(predicate);
            return _mapper.Map<ICollection<Status>,ICollection<StatusDTO>>(entity);
        }

        public override StatusDTO GetOne<StatusDTO>(int id)
        {
            var entity = _unitOfWork.StatusRepository.GetOne(id);
            return _mapper.Map<Status, StatusDTO>(entity);
        }

        public override StatusDTO GetOne<StatusDTO>(Expression<Func<Status, bool>> predicate)
        {
            var entity =_unitOfWork.StatusRepository.GetOne(predicate);
            return _mapper.Map<Status, StatusDTO>(entity);

        }

        public override void Update(Status entity)
        {
            _unitOfWork.StatusRepository.Update(entity);
            _unitOfWork.Commit();
        }
    }
}