using System;
using System.Collections.Generic;
using System.Text;

namespace Applicanty.Data.Entity
{
    public class VacancyTecnology
    {
        public long VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }

        public int TechnologyId  { get; set; }
        public Technology Technology { get; set; }
    }
}
