namespace Applicanty.Core.Model
{
    public class VacancyCandidate
    {
        public int VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }

        public int CandidateId  { get; set; }
        public Candidate Candidate { get; set; }
    }
}
