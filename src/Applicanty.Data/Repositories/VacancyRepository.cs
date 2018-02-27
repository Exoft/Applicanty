using Applicanty.Core.Entities;
using Applicanty.Core.Data.Repositories;
using System.Security.Principal;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace Applicanty.Data.Repositories
{
    internal class VacancyRepository : TrackableRepository<Vacancy>, IVacancyRepository
    {
        public VacancyRepository(AtsDbContext context, IPrincipal principal)
            : base(context, principal)
        { }

        public override Vacancy Update(Vacancy entity)
        {
            var vacancy = GetWithInclude(f => f.VacancyTechnologies)
                          .FirstOrDefault(f => f.Id == entity.Id);

            if (entity.VacancyTechnologies != null && entity.VacancyTechnologies.Count != 0)
                UpdateManyToMany(vacancy.VacancyTechnologies, entity.VacancyTechnologies, x => x.TechnologyId);

            return base.Update(entity);
        }

        public void DetachCandidate(Vacancy newVacancy)
        {
            var vacancy = GetWithInclude(f => f.VacancyCandidates)
                          .FirstOrDefault(f => f.Id == newVacancy.Id);

            if (newVacancy.VacancyCandidates != null)
                UpdateManyToMany(vacancy.VacancyCandidates, newVacancy.VacancyCandidates, x => x.CandidateId);
        }
    }
}