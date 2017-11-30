using System;
using System.Collections.Generic;
using System.Text;

namespace Applicant.Model.Entity
{
    public class Status:IPrimary<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsArchived { get; set; }
    }
}
