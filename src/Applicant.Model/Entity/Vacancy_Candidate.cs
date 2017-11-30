using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Applicant.Model.Entity
{
    public class Vacancy_Candidate
    {
        [Key]
        public long IdCandidate { get; set; }
        [Key]
        public long IdVacancy { get; set; }
    }
}
