using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Applicant.Model.Entity
{
    public class Vacancy_Technology
    {
        [Key]
        public int IdVacancy { get; set; }
        [Key]
        public int IdTechnology { get; set; }
    }
}
