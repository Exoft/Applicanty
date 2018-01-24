using System;
using Applicanty.Data.Repositories;
using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Data;
using System.Security.Principal;

namespace Applicanty.Data.UnitOfWork.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private AtsDbContext _dbContext;

        private ICandidateRepository _candidateRepository;
        private IVacancyRepository _vacancyRepository;
        private IStatusRepository _statusRepository;
        private ITechnologyRepository _technologyRepository;
        private IVacancyCandidateRepository _vacancyCandidateRepository;

        private IPrincipal _principal;

        public IVacancyRepository VacancyRepository
        {
            get
            {
                if (_vacancyRepository == null)
                    _vacancyRepository = new VacancyRepository(_dbContext, _principal);

                return _vacancyRepository;
            }
        }

        public IVacancyCandidateRepository VacancyCandidateRepository
        {
            get
            {
                if (_vacancyCandidateRepository == null)
                    _vacancyCandidateRepository = new VacancyCandidateRepository(_dbContext);

                return _vacancyCandidateRepository;
            }
        }

        public ICandidateRepository CandidateRepository
        {
            get
            {
                if (_candidateRepository == null)
                    _candidateRepository = new CandidateRepository(_dbContext);

                return _candidateRepository;
            }
        }

        public IStatusRepository StatusRepository
        {
            get
            {
                if (_statusRepository == null)
                    _statusRepository = new StatusRepository(_dbContext);

                return _statusRepository;
            }
        }

        public ITechnologyRepository TechnologyRepository
        {
            get
            {
                if (_technologyRepository == null)
                    _technologyRepository = new TechnologyRepository(_dbContext);

                return _technologyRepository;
            }
        }

        public UnitOfWork(IPrincipal principal)
        {
            _dbContext = new AtsDbContext();
            _principal = principal;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }

        public void Commit() =>
            _dbContext.SaveChanges();
    }
}