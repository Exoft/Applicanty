using System;
using Applicanty.Data.Repositories;
using Applicanty.Data.Repositories.Abstract;
using Applicanty.Data.UnitOfWork.Interface;


namespace Applicanty.Data.UnitOfWork.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private AtsDbContext _dbContext;

        private ICandidateRepository _candidateRepository;
        private IVacancyRepository _vacancyRepository;
        private IExperienceRepository _experienceRepository;
        private IStatusRepository _statusRepository;
        private ITechnologyRepository _technologyRepository;

        public IVacancyRepository VacancyRepository
        {
            get
            {
                if (_vacancyRepository == null)
                    _vacancyRepository = new VacancyRepository(_dbContext);

                return _vacancyRepository;
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

        public IExperienceRepository ExperienceRepository
        {
            get
            {
                if (_experienceRepository == null)
                    _experienceRepository = new ExperienceRepository(_dbContext);

                return _experienceRepository;
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

        public AtsDbContext DbContext => _dbContext;

        public UnitOfWork()
        {
            _dbContext = new AtsDbContext();
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
