using Applicanty.Data.Entity.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Applicanty.Data.Entity
{
    public class Technology : IPrimary<int>
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<CandidateTechnology> CanditatTechnologies { get; set; }
        public ICollection<VacancyTechnology> VacancyTecnologies { get; set; }
    }
}
