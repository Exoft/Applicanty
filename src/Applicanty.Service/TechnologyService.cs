using Applicanty.Core.Entities;
using Applicanty.Core.Data;
using Applicanty.Services.Abstract;
using AutoMapper;
using Applicanty.Core.Data.Repositories;

namespace Applicanty.Services.Services
{
    public class TechnologyService : BaseService<Technology, ITechnologyRepository>, ITechnologyService
    {
        public TechnologyService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        protected override ITechnologyRepository InitRepository()
            => UnitOfWork.TechnologyRepository;
    }
}
