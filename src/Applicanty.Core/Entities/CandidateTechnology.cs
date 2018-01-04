namespace Applicanty.Core.Entities
{
    public class CandidateTechnology
    {
        public int TechnologyId { get; set; }
        public Technology Technology { get; set; }

        public int CandidateId  { get; set; }
        public Candidate Candidate { get; set; }
    }
}
