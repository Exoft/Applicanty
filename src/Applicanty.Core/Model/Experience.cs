using Applicanty.Core.Abstract;
using System.Collections.Generic;

namespace Applicanty.Core.Model
{
    public class Experience : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        ICollection<Candidate> Candidates { get; set; }
        ICollection<Vacancy> Vacancies { get; set; }
    }
}