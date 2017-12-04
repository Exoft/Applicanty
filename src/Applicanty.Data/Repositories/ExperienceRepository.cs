using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Applicanty.Data.Entity;
using Applicanty.Data.Entity.Abstract;

namespace Applicanty.Data.Repositories
{
    public class ExperienceRepository : EntityBaseRepository<Exception, int>, IExperienceRepository
    {
        public ExperienceRepository(AtsDbContext context) : base(context)
        {
        }
    }

}
