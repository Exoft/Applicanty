using Applicanty.Core.Abstract;
using Microsoft.AspNetCore.Identity;
using System;

namespace Applicanty.Core.Model
{
    public class User : IdentityUser<int>, IEntity 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsArchived { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
