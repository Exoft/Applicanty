using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Applicant.Model.Entity
{
    public class Candidate_Vacancy
    {
        [Key]
        public long IdCandidate { get; set; }
        [Key]
        public long IdVacancy { get; set; }

    }
}
