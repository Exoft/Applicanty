using System;
using System.Collections.Generic;
using System.Text;

namespace Applicant.Data.Entity
{
    public class CanditatTechnology
    {
        public int TechnologyId { get; set; }
        public Technology Technology { get; set; }

        public long CandidatId  { get; set; }
        public Candidate Candidate { get; set; }
    }
}
