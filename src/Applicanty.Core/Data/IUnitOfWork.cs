using Applicanty.Core.Data.Repositories;
using System;

namespace Applicanty.Core.Data
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
