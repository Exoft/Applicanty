using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Applicant.Model.Entity
{
    public class Candidate_Technology
    {
        [Key]
        public long IdCandidate { get; set; }
        [Key]
        public long IdTechnology { get; set; }
    }
}
