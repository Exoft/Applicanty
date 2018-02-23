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
            var vacancy = GetWithInclude(f => f.VacancyTechnologies, f => f.VacancyCandidates)
                          .FirstOrDefault(f => f.Id == entity.Id);

            if (entity.VacancyTechnologies != null)
                UpdateManyToMany(vacancy.VacancyTechnologies, entity.VacancyTechnologies, x => x.TechnologyId);

            if (entity.VacancyCandidates != null)
                UpdateManyToMany(vacancy.VacancyCandidates, entity.VacancyCandidates, x => x.CandidateId);

            return base.Update(entity);
        }
    }
}