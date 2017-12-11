using Applicanty.Data.Entity;
using Applicanty.Data.Repositories;
using Applicanty.Data.UnitOfWork.Interface;
using System.Collections.Generic;

namespace Applicanty.Data.Services
{
    public class ExperienceService : EntityService<Experience, int>, IExperienceService
    {
        IUnitOfWork _unitOfWork;
        IExperienceRepository _experienceRepository;

        public ExperienceService(IUnitOfWork unitOfWork, IExperienceRepository experienceRepository) 
            : base(unitOfWork, experienceRepository)
        {
            _unitOfWork = unitOfWork;
            _experienceRepository = experienceRepository;
        }

        public ICollection<Experience> GetAll()
        {
            return _experienceRepository.GetAll();
        }

        public Experience GetOne(int id)
        {
            return _experienceRepository.GetOne(id);
        }

        public void Add(Experience obj)
        {
            _experienceRepository.Add(obj);
            _unitOfWork.Commit();
        }

        public void Update(Experience obj)
        {
            _experienceRepository.Update(obj);
            _unitOfWork.Commit();
        }
    }
}
