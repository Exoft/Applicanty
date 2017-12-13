using Applicanty.Data.Entity;
using Applicanty.Data.Repositories;
using Applicanty.Data.UnitOfWork.Interface;
using System.Collections.Generic;

namespace Applicanty.Data.Services
{
    public class CandidateService : EntityService<Candidate, long>, ICandidateService
    {
        IUnitOfWork _unitOfWork;
        ICandidateRepository _candidateRepository;

        public CandidateService(IUnitOfWork unitOfWork, ICandidateRepository candidateRepository)
            : base(unitOfWork, candidateRepository)
        {
            _unitOfWork = unitOfWork;
            _candidateRepository = candidateRepository;
        }

        public Candidate GetOne(long Id)
        {
            return _candidateRepository.GetOne(Id);
        }

        public ICollection<Candidate> GetAll()
        {
            return _candidateRepository.GetAll();
        }

        public void Create(Candidate obj)
        {
            _candidateRepository.Add(obj);
            _unitOfWork.Commit();
        }

        public void Update(Candidate obj)
        {
            _candidateRepository.Update(obj);
            _unitOfWork.Commit();
        }

        public void Archive(long id)
        {
            _candidateRepository.Archive(id);
            _unitOfWork.Commit();
        }

        public void Archive(ICollection<Candidate> list)
        {
            _candidateRepository.Archive(list);
            _unitOfWork.Commit();
        }

        public void UnArchive(long id)
        {
            _candidateRepository.UnArchive(id);
            _unitOfWork.Commit();
        }

        public void UnArchive(ICollection<Candidate> list)
        {
            _candidateRepository.UnArchive(list);
            _unitOfWork.Commit();
        }
    }
}
