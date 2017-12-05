using Applicanty.Data.Entity;
using Applicanty.Data.Repositories;
using Applicanty.Data.UnitOfWork.Interface;

namespace Applicanty.Data.Services
{
    public class UserSerices : EntityService<User, long>, IUserServices
    {
        private IUnitOfWork _unitOfWork;
        private IUserRepository _userRepository;

        public UserSerices(IUnitOfWork unitOfWork, IUserRepository userRepository)
            :base(unitOfWork, userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;   
        }
    }
}