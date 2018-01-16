using Applicanty.Core.Data;
using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Entities;
using Applicanty.Services.Abstract;
using AutoMapper;

namespace Applicanty.Services.Services
{
    public class StatusService : BaseService<Status, IStatusRepository>, IStatusService
    {
        public StatusService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        protected override IStatusRepository InitRepository() =>
            UnitOfWork.StatusRepository;
    }
}