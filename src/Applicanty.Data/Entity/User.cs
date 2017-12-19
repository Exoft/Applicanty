using Applicanty.Data.Entity.Abstract;
using Microsoft.AspNetCore.Identity;
using System;

namespace Applicanty.Data.Entity
{
    public class User : IdentityUser<long>, IPrimary<long>
    {
        public string LastName { get; set; }
        public bool IsArchived { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
