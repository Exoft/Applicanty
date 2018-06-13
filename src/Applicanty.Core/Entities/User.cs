using Applicanty.Core.Entities.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Applicanty.Core.Entities
{
    public class User : IdentityUser<int>, IEntity 
    {
        public User()
        {
            Comments = new HashSet<Comment>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsArchived { get; set; }
        public DateTime UpdatedOn { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
