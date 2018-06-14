using Applicanty.Core.Entities;
using Applicanty.Core.Data.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Applicanty.Data.Repositories
{
    internal class CandidateRepository : TrackableRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(AtsDbContext context, IPrincipal principal)
            : base(context, principal)
        { }

        public override Candidate Update(Candidate entity)
        {
            if (entity.CandidateTechnologies != null)
            {
                var vacancy = GetWithInclude(f => f.CandidateTechnologies).FirstOrDefault(f => f.Id == entity.Id);

                foreach (var item in vacancy.CandidateTechnologies.Where(currentTechnology =>
                                    !entity.CandidateTechnologies.Any(newTechnology =>
                                    newTechnology.TechnologyId == currentTechnology.TechnologyId)))
                    _entities.Entry(item).State = EntityState.Deleted;

                foreach (var item in entity.CandidateTechnologies.Where(newTechnology =>
                                    !vacancy.CandidateTechnologies.Any(currentTechnology =>
                                    currentTechnology.TechnologyId == newTechnology.TechnologyId)))
                    _entities.Entry(item).State = EntityState.Added;
            }

            return base.Update(entity);
        }
    }
}
