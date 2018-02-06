using Applicanty.Core.Entities;
using Applicanty.Core.Data.Repositories;
using System.Security.Principal;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Applicanty.Data.Repositories
{
    internal class VacancyRepository : TrackableRepository<Vacancy>, IVacancyRepository
    {
        public VacancyRepository(AtsDbContext context, IPrincipal principal)
            : base(context, principal)
        { }

        public override Vacancy Update(Vacancy entity)
        {
            if (entity.VacancyTechnologies != null)
            {
                var vacancy = GetWithInclude(f => f.VacancyTechnologies).FirstOrDefault(f => f.Id == entity.Id);

                foreach (var item in vacancy.VacancyTechnologies.Where(currentTechnology =>
                                    !entity.VacancyTechnologies.Any(newTechnology => newTechnology.TechnologyId ==
                                                                                    currentTechnology.TechnologyId)))
                    _entities.Entry(item).State = EntityState.Deleted;

                foreach (var item in entity.VacancyTechnologies.Where(newTechnology =>
                                    !vacancy.VacancyTechnologies.Any(currentTechnology => currentTechnology.TechnologyId ==
                                                                                            newTechnology.TechnologyId)))
                    _entities.Entry(item).State = EntityState.Added;
            }

            return base.Update(entity);
        }
    }
}