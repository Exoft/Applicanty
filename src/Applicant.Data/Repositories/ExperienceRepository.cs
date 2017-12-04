using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Applicant.Data.Entity;
using Applicant.Data.Entity.Abstract;

namespace Applicant.Data.Repositories
{
    public class ExperienceRepository : EntityBaseRepository<Exception, int>, IExperienceRepository
    {
        public ExperienceRepository(AtsDbContext context) : base(context)
        {
        }
    }

}
