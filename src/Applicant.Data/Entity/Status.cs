using System;
using System.Collections.Generic;
using System.Text;
using Applicant.Data.Entity.Abstract;

namespace Applicant.Data.Entity
{
    public class Status:IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsArchived { get; set; }
    }
}
