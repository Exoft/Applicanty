namespace Applicanty.Data.Entity
{
    public class VacancyCandidate
    {
        public long VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }

        public long CandidatId  { get; set; }
        public Candidate Candidate { get; set; }
    }
}
