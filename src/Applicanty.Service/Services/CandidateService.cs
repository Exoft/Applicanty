using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Applicanty.Core.Model;
using Applicanty.Data.UnitOfWork.Interface;
using Applicanty.Services.Abstract;

namespace Applicanty.Services.Services
{
    public class CandidateService : StateableService<Candidate>, ICandidateService
    {
        public CandidateService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {}

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

        public override IEnumerable<Candidate> GetAll()
        {
            return _unitOfWork.CandidateRepository.GetAll();
        }

        public override ICollection<Candidate> GetAll(Expression<Func<Candidate, bool>> predicate)
        {
            return _unitOfWork.CandidateRepository.GetAll(predicate);
        }

        public override Candidate GetOne(int id)
        {
            return _unitOfWork.CandidateRepository.GetOne(id);
        }

        public override Candidate GetOne(Expression<Func<Candidate, bool>> predicate)
        {
            return _unitOfWork.CandidateRepository.GetOne(predicate);
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
