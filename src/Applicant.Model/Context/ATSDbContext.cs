using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Applicant.Model.Entity;

namespace Applicant.Model.Context
{
    public class ATSDbContext : DbContext
    {
        public ATSDbContext() { }
        public ATSDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }


}
