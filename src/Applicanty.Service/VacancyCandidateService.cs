using Applicanty.Core.Data;
using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Entities;
using Applicanty.Core.Services;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Applicanty.Services.Services
{
    public class VacancyCandidateService : BaseService<VacancyCandidate, IVacancyCandidateRepository>, IVacancyCandidateService
    {
        public VacancyCandidateService(IUnitOfWork unitOfWork, IMapper mapper) 
            : base(unitOfWork, mapper)
        {}

        protected override IVacancyCandidateRepository InitRepository()=>
            UnitOfWork.VacancyCandidateRepository;

        public IEnumerable<VacancyCandidate> GetByVacancy(int vacancyId)
        {
            return Repository.GetAll(item => item.VacancyId == vacancyId);
        }

        public IEnumerable<VacancyCandidate> GetByVacancyAndStage(int vacancyId, int stageId)
        {
            return GetByVacancy(vacancyId).Where(item => (int)item.VacancyStage == stageId);
        }
    }
}