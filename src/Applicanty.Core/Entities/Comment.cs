using Applicanty.Core.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Applicanty.Core.Entities
{
    public class Comment : Statable, IEntity, ITrackable
    {
        public int Id { get; set; }
        public string CommentText { get; set; }

        public int VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }

        public DateTime CreatedAt { get; set; }
        [ForeignKey("User")]
        public int CreatedBy { get; set; }
        public User User { get; set; }

        public DateTime ModifiedAt { get; set; }
        public int ModifiedBy { get; set; }
        }
}
