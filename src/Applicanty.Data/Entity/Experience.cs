using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Applicanty.Data.Entity.Abstract;

namespace Applicanty.Data.Entity
{
    public class Experience :IEntity<int>
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }


        ICollection<Candidate> Candidates { get; set; }
        ICollection<Vacancy> Vacancies { get; set; }

    }
}
