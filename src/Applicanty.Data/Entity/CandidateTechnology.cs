namespace Applicanty.Data.Entity
{
    public class CandidateTechnology
    {
        public int TechnologyId { get; set; }
        public Technology Technology { get; set; }

        public long CandidateId  { get; set; }
        public Candidate Candidate { get; set; }
    }
}
