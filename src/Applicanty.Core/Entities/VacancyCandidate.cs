﻿using Applicanty.Core.Enums;

namespace Applicanty.Core.Entities
{
    public class VacancyCandidate
    {
        public int VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }

        public int CandidateId  { get; set; }
        public Candidate Candidate { get; set; }

        public VacancyStage VacancyStage { get; set; }
    }
}