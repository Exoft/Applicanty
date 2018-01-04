using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Applicanty.Core.Entities;
using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Data;
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
            UnitOfWork.CandidateRepository.Archive(id);
            UnitOfWork.Commit();
        }

        public override void Archive(ICollection<Candidate> list)
        {
            UnitOfWork.CandidateRepository.Archive(list);
            UnitOfWork.Commit();
        }

        public override void Create(Candidate entity)
        {
            UnitOfWork.CandidateRepository.Add(entity);
            UnitOfWork.Commit();
        }

        public override IEnumerable<CandidateDTO> GetAll<CandidateDTO>()
        {
            var entity = UnitOfWork.CandidateRepository.GetAll();
            return Mapper.Map<IEnumerable<Candidate>, IEnumerable<CandidateDTO>>(entity);
        }

        public override ICollection<CandidateDTO> GetAll<CandidateDTO>(Expression<Func<Candidate, bool>> predicate)
        {
            var entity =UnitOfWork.CandidateRepository.GetAll(predicate);
            return Mapper.Map<ICollection<Candidate>, ICollection<CandidateDTO>>(entity);

        }

        public override CandidateDetailsDTO GetOne<CandidateDetailsDTO>(int id)
        {
            var entity = UnitOfWork.CandidateRepository.GetOne(id);
            return Mapper.Map<Candidate, CandidateDetailsDTO>(entity);
        }

        public override CandidateDetailsDTO GetOne<CandidateDetailsDTO>(Expression<Func<Candidate, bool>> predicate)
        {
            var entity = UnitOfWork.CandidateRepository.GetOne(predicate);
            return Mapper.Map<Candidate, CandidateDetailsDTO>(entity);
        }

        public override void UnArchive(int id)
        {
            UnitOfWork.CandidateRepository.UnArchive(id);
            UnitOfWork.Commit();
        }

        public override void UnArchive(ICollection<Candidate> list)
        {
            UnitOfWork.CandidateRepository.UnArchive(list);
            UnitOfWork.Commit();
        }

        public override void Update(Candidate entity)
        {
            UnitOfWork.CandidateRepository.Update(entity);
            UnitOfWork.Commit();
        }

        protected override IEntityBaseRepository<Candidate> InitRepository()
        {
            return UnitOfWork.CandidateRepository;
        }
    }
}
