using Applicanty.Core.Data;
using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Entities;
using Applicanty.Services.Abstract;
using AutoMapper;

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
