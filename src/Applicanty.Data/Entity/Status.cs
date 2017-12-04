using System;
using System.Collections.Generic;
using System.Text;
using Applicanty.Data.Entity.Abstract;

namespace Applicanty.Data.Entity
{
    public class Status:IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsArchived { get; set; }
    }
}
