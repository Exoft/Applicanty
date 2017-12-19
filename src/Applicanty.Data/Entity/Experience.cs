using Applicanty.Data.Entity.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Applicanty.Data.Entity
{
    public class Experience : IPrimary<int>
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        ICollection<Candidate> Candidates { get; set; }
        ICollection<Vacancy> Vacancies { get; set; }
    }
}