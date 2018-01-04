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
    public class CandidateService : StateableService<Candidate>, ICandidateService
    {
        public CandidateService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override void Archive(int id)
        {
            _unitOfWork.CandidateRepository.Archive(id);
            _unitOfWork.Commit();
        }

        public override void Archive(ICollection<Candidate> list)
        {
            _unitOfWork.CandidateRepository.Archive(list);
            _unitOfWork.Commit();
        }

        public override void Create(Candidate entity)
        {
            _unitOfWork.CandidateRepository.Add(entity);
            _unitOfWork.Commit();
        }

        public override IEnumerable<CandidateDTO> GetAll<CandidateDTO>()
        {
            var entity = _unitOfWork.CandidateRepository.GetAll();
            return _mapper.Map<IEnumerable<Candidate>, IEnumerable<CandidateDTO>>(entity);
        }

        public override ICollection<CandidateDTO> GetAll<CandidateDTO>(Expression<Func<Candidate, bool>> predicate)
        {
            var entity =_unitOfWork.CandidateRepository.GetAll(predicate);
            return _mapper.Map<ICollection<Candidate>, ICollection<CandidateDTO>>(entity);

        }

        public override CandidateDetailsDTO GetOne<CandidateDetailsDTO>(int id)
        {
            var entity = _unitOfWork.CandidateRepository.GetOne(id);
            return _mapper.Map<Candidate, CandidateDetailsDTO>(entity);
        }

        public override CandidateDetailsDTO GetOne<CandidateDetailsDTO>(Expression<Func<Candidate, bool>> predicate)
        {
            var entity = _unitOfWork.CandidateRepository.GetOne(predicate);
            return _mapper.Map<Candidate, CandidateDetailsDTO>(entity);
        }

        public override void UnArchive(int id)
        {
            _unitOfWork.CandidateRepository.UnArchive(id);
            _unitOfWork.Commit();
        }

        public override void UnArchive(ICollection<Candidate> list)
        {
            _unitOfWork.CandidateRepository.UnArchive(list);
            _unitOfWork.Commit();
        }

        public override void Update(Candidate entity)
        {
            _unitOfWork.CandidateRepository.Update(entity);
            _unitOfWork.Commit();
        }
    }
}
