﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Applicanty.Data
{
    public class AtsDbContextFactory : IDesignTimeDbContextFactory<AtsDbContext>
    {
        public AtsDbContext Create(DbContextFactoryOptions options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AtsDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AtsDB;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new AtsDbContext(optionsBuilder.Options);
        }

        public AtsDbContext CreateDbContext(string[] args)
        {
            throw new System.NotImplementedException();
        }
    }
}