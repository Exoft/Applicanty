using Applicanty.Core.Abstract;
using System.Collections.Generic;

namespace Applicanty.Core.Model
{
    public class Technology : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<CandidateTechnology> CandidateTechnologies { get; set; }
        public ICollection<VacancyTechnology> VacancyTechnologies { get; set; }
    }
}
