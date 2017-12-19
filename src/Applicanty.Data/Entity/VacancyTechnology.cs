namespace Applicanty.Data.Entity
{
    public class VacancyTechnology
    {
        public long VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }

        public int TechnologyId  { get; set; }
        public Technology Technology { get; set; }
    }
}
