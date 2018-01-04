using Applicanty.Core.Entities.Abstract;
using Microsoft.AspNetCore.Identity;
using System;

namespace Applicanty.Core.Entities
{
    public class User : IdentityUser<int>, IEntity 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsArchived { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
