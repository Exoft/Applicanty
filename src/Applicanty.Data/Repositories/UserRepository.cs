using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Applicanty.Data.Entity;
using Applicanty.Data.Entity.Abstract;

namespace Applicanty.Data.Repositories
{
    public class UserRepository : EntityBaseRepository<User, long>, IUserRepository
    {
        public UserRepository(AtsDbContext context) 
            : base(context)
        {
        }
    }
}
