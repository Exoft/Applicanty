using Applicanty.Core.Data;
using Applicanty.Core.Data.Repositories;
using Applicanty.Core.Entities;
using Applicanty.Services.Abstract;
using AutoMapper;

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
