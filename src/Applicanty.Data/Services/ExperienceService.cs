using Applicanty.Data.Entity;
using Applicanty.Data.Repositories;
using Applicanty.Data.UnitOfWork.Interface;

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
    }
}
