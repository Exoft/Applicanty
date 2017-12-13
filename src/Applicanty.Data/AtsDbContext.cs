using Applicanty.Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Applicanty.Data
{
    public class AtsDbContext : IdentityDbContext<User, IdentityRole<long>, long>
    {

        public AtsDbContext(DbContextOptions<AtsDbContext> options)
        : base(options)
        {
        }

        public AtsDbContext()
        {
                
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VacancyCandidat>()
                .HasKey(t => new { t.VacancyId, t.CandidatId });

            modelBuilder.Entity<VacancyCandidat>()
                .HasOne(pt => pt.Vacancy)
                .WithMany(p => p.VacancyCandidats)
                .HasForeignKey(pt => pt.VacancyId);

            modelBuilder.Entity<VacancyCandidat>()
                .HasOne(pt => pt.Candidate)
                .WithMany(t => t.VacancyCandidats)
                .HasForeignKey(pt => pt.CandidatId);

            modelBuilder.Entity<CanditatTechnology>()
                .HasKey(t => new { t.TechnologyId, t.CandidatId });

            modelBuilder.Entity<CanditatTechnology>()
                .HasOne(pt => pt.Technology)
                .WithMany(p => p.CanditatTechnologies)
                .HasForeignKey(pt => pt.TechnologyId);

            modelBuilder.Entity<CanditatTechnology>()
                .HasOne(pt => pt.Candidate)
                .WithMany(t => t.CanditatTechnologies)
                .HasForeignKey(pt => pt.CandidatId);

            modelBuilder.Entity<VacancyTecnology>()
                .HasKey(t => new { t.TechnologyId, t.VacancyId });

            modelBuilder.Entity<VacancyTecnology>()
                .HasOne(pt => pt.Technology)
                .WithMany(p => p.VacancyTecnologies)
                .HasForeignKey(pt => pt.TechnologyId);

            modelBuilder.Entity<VacancyTecnology>()
                .HasOne(pt => pt.Vacancy)
                .WithMany(t => t.VacancyTecnologies)
                .HasForeignKey(pt => pt.VacancyId);
        }
    }

}

