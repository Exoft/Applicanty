using Applicanty.Data.Entity;
using Applicanty.Data.Repositories;
using Applicanty.Data.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Applicanty.Data.Services
{
    public class TechnologyService : EntityService<Technology, int>, ITechnologyService
    {
        IUnitOfWork _unitOfWork;
        ITechnologyRepository _technologyRepository;
        public TechnologyService(IUnitOfWork unitOfWork, ITechnologyRepository technologyRepository)
            :base(unitOfWork, technologyRepository)
        {
            _unitOfWork = unitOfWork;
            _technologyRepository = technologyRepository;
        }
        public Technology GetById(int Id)
        {
            return _technologyRepository.GetOne(Id);
        }
    }
}
