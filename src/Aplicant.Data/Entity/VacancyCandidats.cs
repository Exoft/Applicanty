using System;
using System.Collections.Generic;
using System.Text;

namespace Applicant.Data.Entity
{
    public class VacancyCandidat
    {
        public long VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }

        public long CandidatId  { get; set; }
        public Candidate Candidate { get; set; }
    }
}
