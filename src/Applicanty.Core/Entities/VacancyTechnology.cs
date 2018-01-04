namespace Applicanty.Core.Entities
{
    public class VacancyTechnology
    {
        public int VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }

        public int TechnologyId  { get; set; }
        public Technology Technology { get; set; }
    }
}
