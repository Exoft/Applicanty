using Applicanty.Core.Entities;
using Applicanty.Core.Data;
using Applicanty.Services.Abstract;
using AutoMapper;
using Applicanty.Core.Data.Repositories;

namespace Applicanty.Services.Services
{
    public class ExperienceService : BaseService<Experience, IExperienceRepository>, IExperienceService
    {
        public ExperienceService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        protected override IExperienceRepository InitRepository() =>
            UnitOfWork.ExperienceRepository;
    }
}
