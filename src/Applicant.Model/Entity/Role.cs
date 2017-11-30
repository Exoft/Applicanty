using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Applicant.Model.Entity
{
    public class Role:IPrimary<int>
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsArchived { get; set; }


    }
}
