using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Applicant.Data.Entity.Abstract;

namespace Applicant.Data.Entity
{
    public class Technology:IEntity<int>
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }


        public ICollection<CanditatTechnology> CanditatTechnologies { get; set; }
        public ICollection<VacancyTecnology> VacancyTecnologies { get; set; }

    }
}
