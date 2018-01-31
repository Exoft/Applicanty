using Applicanty.Core.Data.Repositories;
using System;

namespace Applicanty.Core.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IVacancyRepository VacancyRepository { get; }
        IVacancyCandidateRepository VacancyCandidateRepository { get; }
        ICandidateRepository CandidateRepository { get; }
        IStatusRepository StatusRepository { get; }
        ITechnologyRepository TechnologyRepository { get; }
        IVacancyTechnologyRepositort VacancyTechnologyRepositort { get; }

        void Commit();
    }
}