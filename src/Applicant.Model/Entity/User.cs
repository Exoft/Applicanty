using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Applicant.Model.Entity
{
    public class User : IPrimary<long>
    {
        public long Id { get; set; }
        [Required, ForeignKey("Role")]
        public int IdRole { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsArchived { get; set; }
        public DateTime UpdatedOn { get; set; }

        public Role Role { get; set; }
    }
}
