using Applicanty.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Applicanty.Data
{
    public class AtsDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public AtsDbContext(DbContextOptions<AtsDbContext> options) : base(options)
        {
        }

        public AtsDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#if DEBUG
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=AtsDB;Integrated Security=True");
#else
                optionsBuilder.UseSqlServer(@"Data Source=office.exoft.net;Initial Catalog=applicanty-db;Integrated Security=False;User ID=sa;Password=M1llions2013;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
#endif
            }
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VacancyCandidate>()
                .HasKey(t => new { t.VacancyId, t.CandidateId });

            modelBuilder.Entity<VacancyCandidate>()
                .HasOne(pt => pt.Vacancy)
                .WithMany(p => p.VacancyCandidates)
                .HasForeignKey(pt => pt.VacancyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VacancyCandidate>()
                .HasOne(pt => pt.Candidate)
                .WithMany(t => t.VacancyCandidates)
                .HasForeignKey(pt => pt.CandidateId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CandidateTechnology>()
                .HasKey(t => new { t.TechnologyId, t.CandidateId });

            modelBuilder.Entity<CandidateTechnology>()
                .HasOne(pt => pt.Technology)
                .WithMany(p => p.CandidateTechnologies)
                .HasForeignKey(pt => pt.TechnologyId);

            modelBuilder.Entity<CandidateTechnology>()
                .HasOne(pt => pt.Candidate)
                .WithMany(t => t.CandidateTechnologies)
                .HasForeignKey(pt => pt.CandidateId);

            modelBuilder.Entity<VacancyTechnology>()
                .HasKey(t => new { t.TechnologyId, t.VacancyId });

            modelBuilder.Entity<VacancyTechnology>()
                .HasOne(pt => pt.Technology)
                .WithMany(p => p.VacancyTechnologies)
                .HasForeignKey(pt => pt.TechnologyId);

            modelBuilder.Entity<VacancyTechnology>()
                .HasOne(pt => pt.Vacancy)
                .WithMany(t => t.VacancyTechnologies)
                .HasForeignKey(pt => pt.VacancyId);

            modelBuilder.Entity<Comment>()
                .HasKey(t => t.Id );

            modelBuilder.Entity<Comment>()
                .HasOne(pt => pt.Vacancy)
                .WithMany(t => t.Comments)
                .HasForeignKey(pt => pt.VacancyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(pt => pt.User)
                .WithMany(t => t.Comments)
                .HasForeignKey(pt => pt.CreatedBy)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}