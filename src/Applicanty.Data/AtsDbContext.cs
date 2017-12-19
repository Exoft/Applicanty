using Applicanty.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=AtsDB;Integrated Security=True");
            }
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VacancyCandidate>()
                .HasKey(t => new { t.VacancyId, t.CandidatId });

            modelBuilder.Entity<VacancyCandidate>()
                .HasOne(pt => pt.Vacancy)
                .WithMany(p => p.VacancyCandidats)
                .HasForeignKey(pt => pt.VacancyId);

            modelBuilder.Entity<VacancyCandidate>()
                .HasOne(pt => pt.Candidate)
                .WithMany(t => t.VacancyCandidats)
                .HasForeignKey(pt => pt.CandidatId);

            modelBuilder.Entity<CandidateTechnology>()
                .HasKey(t => new { t.TechnologyId, t.CandidatId });

            modelBuilder.Entity<CandidateTechnology>()
                .HasOne(pt => pt.Technology)
                .WithMany(p => p.CanditatTechnologies)
                .HasForeignKey(pt => pt.TechnologyId);

            modelBuilder.Entity<CandidateTechnology>()
                .HasOne(pt => pt.Candidate)
                .WithMany(t => t.CanditatTechnologies)
                .HasForeignKey(pt => pt.CandidatId);

            modelBuilder.Entity<VacancyTechnology>()
                .HasKey(t => new { t.TechnologyId, t.VacancyId });

            modelBuilder.Entity<VacancyTechnology>()
                .HasOne(pt => pt.Technology)
                .WithMany(p => p.VacancyTecnologies)
                .HasForeignKey(pt => pt.TechnologyId);

            modelBuilder.Entity<VacancyTechnology>()
                .HasOne(pt => pt.Vacancy)
                .WithMany(t => t.VacancyTecnologies)
                .HasForeignKey(pt => pt.VacancyId);
        }
    }
}