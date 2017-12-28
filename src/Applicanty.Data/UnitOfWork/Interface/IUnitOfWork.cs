using Applicanty.Data.Repositories.Abstract;
using System;

namespace Applicanty.Data.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable 
    {
        IVacancyRepository VacancyRepository { get;  }
        ICandidateRepository CandidateRepository { get;  }
        IExperienceRepository ExperienceRepository { get; }
        IStatusRepository StatusRepository { get; }
        ITechnologyRepository TechnologyRepository { get; }

        void Commit();
    }
}
