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
    public class TechnologyService : BaseService<Technology>, ITechnologyService
    {
        public TechnologyService(IUnitOfWork unitOfWork, IMapper mapper)
            :base(unitOfWork,mapper)
        {}

        public override void Create(Technology entity)
        {
            _unitOfWork.TechnologyRepository.Add(entity);
            _unitOfWork.Commit();
        }

        public override IEnumerable<TechnologyDTO> GetAll<TechnologyDTO>()
        {
            var entity = _unitOfWork.TechnologyRepository.GetAll();
            return _mapper.Map<IEnumerable<Technology>,IEnumerable<TechnologyDTO>>(entity);
        }

        public override ICollection<TechnologyDTO> GetAll<TechnologyDTO>(Expression<Func<Technology, bool>> predicate)
        {
            var entity = _unitOfWork.TechnologyRepository.GetAll(predicate);
            return _mapper.Map<ICollection<Technology>, ICollection<TechnologyDTO>>(entity);
        }

        public override TechnologyDTO GetOne<TechnologyDTO>(int id)
        {
            var entity = _unitOfWork.TechnologyRepository.GetOne(id);
            return _mapper.Map<Technology,TechnologyDTO>(entity);
        }

        public override TechnologyDTO GetOne<TechnologyDTO>(Expression<Func<Technology, bool>> predicate)
        {
            var entity = _unitOfWork.TechnologyRepository.GetOne(predicate);
            return _mapper.Map<Technology, TechnologyDTO>(entity);

        }

        public override void Update(Technology entity)
        {
            _unitOfWork.TechnologyRepository.Update(entity);
            _unitOfWork.Commit();
        }
    }
}
