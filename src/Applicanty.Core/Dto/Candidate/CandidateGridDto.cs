﻿using Applicanty.Core.Enums;
using System;

namespace Applicanty.Core.Dto
{
    public class CandidateGridDto
    {
        public int Id { get; set; }
        public int ExperienceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string LinkedIn { get; set; }
        public string Phone { get; set; }
        public string CVPath { get; set; }
        public StatusType StatusId { get; set; }
    }
}
