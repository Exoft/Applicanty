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

        public ICollection<CandidateTechnology> CandidateTechnologies { get; set; }
        public ICollection<VacancyTechnology> VacancyTechnologies { get; set; }
    }
}
