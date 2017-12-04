using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Applicanty.Data.Entity.Abstract;

namespace Applicanty.Data.Entity
{
    public class User : IdentityUser<long>  //, IPrimary<long>
    {
        
       // public new long Id { get; set; }
        public string LastName { get; set; }
        public bool IsArchived { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
