using Applicanty.Data.Entity;
using Applicanty.Data.Repositories;
using Applicanty.Data.UnitOfWork.Interface;

namespace Applicanty.Data.Services
{
    public class StatusService : EntityService<Status, int>, IStatusService
    {
        private IUnitOfWork _unitOfWork;
        private IStatusRepository _statusRepository;

        public StatusService(IUnitOfWork unitOfWork, IStatusRepository statusRepository)
            :base(unitOfWork, statusRepository)
        {
            _unitOfWork = unitOfWork;
            _statusRepository = statusRepository;   
        }

    }
}