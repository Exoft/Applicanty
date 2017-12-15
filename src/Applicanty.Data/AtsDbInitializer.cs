using Applicanty.Data.Entity;
using System;
using System.Linq;

namespace Applicanty.Data
{
    public static class AtsDbInitializer
    {
        public static void Initialize(AtsDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Experiences.Any())
            {
                context.Experiences.Add(new Experience { Name = "Senior" }); context.SaveChanges();
                context.Experiences.Add(new Experience { Name = "Middle" }); context.SaveChanges();
                context.Experiences.Add(new Experience { Name = "Junior" }); context.SaveChanges();
                context.Experiences.Add(new Experience { Name = "Trainee" }); context.SaveChanges();
            }

            if (!context.Roles.Any())
            {
                context.Roles.Add(new Microsoft.AspNetCore.Identity.IdentityRole<long> { Name = "Admininstrator", NormalizedName = "admin" }); context.SaveChanges();
                context.Roles.Add(new Microsoft.AspNetCore.Identity.IdentityRole<long> { Name = "Moderator", NormalizedName = "mod" }); context.SaveChanges();
                context.Roles.Add(new Microsoft.AspNetCore.Identity.IdentityRole<long> { Name = "User", NormalizedName = "usr" }); context.SaveChanges();
            }

            if (!context.Statuses.Any())
            {
                context.Add(new Status { Name = "To process", IsArchived = false }); context.SaveChanges();
                context.Add(new Status { Name = "Selected", IsArchived = false }); context.SaveChanges();
                context.Add(new Status { Name = "Contacted", IsArchived = false }); context.SaveChanges();
                context.Add(new Status { Name = "Not interested in this time", IsArchived = false }); context.SaveChanges();
                context.Add(new Status { Name = "Interviewed", IsArchived = false }); context.SaveChanges();
                context.Add(new Status { Name = "Rejected", IsArchived = false }); context.SaveChanges();
                context.Add(new Status { Name = "Offer Sent", IsArchived = false }); context.SaveChanges();
                context.Add(new Status { Name = "Declined offer", IsArchived = false }); context.SaveChanges();
                context.Add(new Status { Name = "Hired", IsArchived = false }); context.SaveChanges();
                context.Add(new Status { Name = "Keep in the pool", IsArchived = false }); context.SaveChanges();
                context.Add(new Status { Name = "Worked at Exoft", IsArchived = false }); context.SaveChanges();
            }

            ///test data
            if (!context.Technologies.Any())
            {
                context.Add(new Technology { Name = "ASP.Net" }); context.SaveChanges();
                context.Add(new Technology { Name = "MS SQL" }); context.SaveChanges();
                context.Add(new Technology { Name = "Angular" }); context.SaveChanges();
                context.Add(new Technology { Name = "Bootstrap" }); context.SaveChanges();
                context.Add(new Technology { Name = "HTML" }); context.SaveChanges();
                context.Add(new Technology { Name = "CSS3" }); context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                context.Users.Add(new User { AccessFailedCount = 1, Email = "victor@mail.com", EmailConfirmed = true, IsArchived = false, UserName = "Victor", LastName = "Pavlik", LockoutEnabled = false, PasswordHash = "5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8", PhoneNumber = "0985434944", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UpdatedOn = DateTime.Now }); context.SaveChanges();
                context.Users.Add(new User { AccessFailedCount = 2, Email = "pashka@mail.com", EmailConfirmed = true, IsArchived = false, UserName = "Pavlo", LastName = "Zibrov", LockoutEnabled = false, PasswordHash = "5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8", PhoneNumber = "0986823454", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UpdatedOn = DateTime.Now }); context.SaveChanges();
                context.Users.Add(new User { AccessFailedCount = 3, Email = "batman@mail.com", EmailConfirmed = true, IsArchived = false, UserName = "Bruce", LastName = "Wayne", LockoutEnabled = false, PasswordHash = "5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8", PhoneNumber = "0986833454", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UpdatedOn = DateTime.Now }); context.SaveChanges();
                context.Users.Add(new User { AccessFailedCount = 4, Email = "stepanchik@mail.com", EmailConfirmed = true, IsArchived = false, UserName = "Stepan", LastName = "Hiha", LockoutEnabled = false, PasswordHash = "5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8", PhoneNumber = "09868344544", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UpdatedOn = DateTime.Now }); context.SaveChanges();
                context.Users.Add(new User { AccessFailedCount = 5, Email = "dudka27@mail.com", EmailConfirmed = true, IsArchived = false, UserName = "Richard", LastName = "Hendrix", LockoutEnabled = false, PasswordHash = "5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8", PhoneNumber = "0986834544", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UpdatedOn = DateTime.Now }); context.SaveChanges();
            };

            if (!context.Vacancies.Any())
            {
                context.Vacancies.Add(new Vacancy
                {
                    CreatedOn = DateTime.Now,
                    IdExperience = 1,
                    IdUser = 1,
                    IsArchived = false,
                    MaxSalary = 300,
                    MinSalary = 250,
                    Title = "Lorem ipsum",
                    UpdatedOn = DateTime.Now,
                    ProjectDescription = "Nunc finibus purus dui, vitae semper nisi cursus eget. Duis sed felis sit amet erat pretium auctor et eu ipsum. Nam venenatis auctor ex a sollicitudin.",
                    JobDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla metus mauris, fermentum convallis interdum nec, semper at nulla. Sed quam massa, posuere vestibulum erat sed, interdum ornare diam.",
                });
                context.SaveChanges();

                context.Vacancies.Add(new Vacancy
                {
                    CreatedOn = DateTime.Now,
                    IdExperience = 2,
                    IdUser = 2,
                    IsArchived = false,
                    MaxSalary = 400,
                    MinSalary = 150,
                    Title = "Lorem ipsum",
                    UpdatedOn = DateTime.Now,
                    ProjectDescription = "Nunc finibus purus dui, vitae semper nisi cursus eget. Duis sed felis sit amet erat pretium auctor et eu ipsum. Nam venenatis auctor ex a sollicitudin.",
                    JobDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla metus mauris, fermentum convallis interdum nec, semper at nulla. Sed quam massa, posuere vestibulum erat sed, interdum ornare diam.",
                });
                context.SaveChanges();

                context.Vacancies.Add(new Vacancy
                {
                    CreatedOn = DateTime.Now,
                    IdExperience = 3,
                    IdUser = 3,
                    IsArchived = false,
                    MaxSalary = 270,
                    MinSalary = 150,
                    Title = "Lorem ipsum",
                    UpdatedOn = DateTime.Now,
                    ProjectDescription = "Nunc finibus purus dui, vitae semper nisi cursus eget. Duis sed felis sit amet erat pretium auctor et eu ipsum. Nam venenatis auctor ex a sollicitudin.",
                    JobDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla metus mauris, fermentum convallis interdum nec, semper at nulla. Sed quam massa, posuere vestibulum erat sed, interdum ornare diam.",
                });
                context.SaveChanges();
            }

            if (!context.Candidates.Any())
            {
                context.Add(new Candidate { Email = "superman_duperman@mail.com", FirstName = "Clark", LastName = "Kent", IdExperience = 4, IsArchived = false, Phone = "06345345997", UpdateOn = DateTime.Now }); context.SaveChanges();
                context.Add(new Candidate { Email = "batman@mail.com", FirstName = "Bruce", LastName = "Wayne", IdExperience = 1, IsArchived = false, Phone = "06763454337", UpdateOn = DateTime.Now }); context.SaveChanges();
                context.Add(new Candidate { Email = "flash@mail.com", FirstName = "Barry", LastName = "Alan", IdExperience = 2, IsArchived = false, Phone = "0676834634", UpdateOn = DateTime.Now }); context.SaveChanges();
                context.Add(new Candidate { Email = "capitan_america@mail.com", FirstName = "Steve", LastName = "Rodgers", IdExperience = 4, IsArchived = false, Phone = "06745654997", UpdateOn = DateTime.Now }); context.SaveChanges();
                context.Add(new Candidate { Email = "hulk@mail.com", FirstName = "Bruce", LastName = "Banner", IdExperience = 3, IsArchived = false, Phone = "0676345697", UpdateOn = DateTime.Now }); context.SaveChanges();
                context.Add(new Candidate { Email = "thor@mail.com", FirstName = "Thor", LastName = "SunOfOdin", IdExperience = 3, IsArchived = false, Phone = "067233997", UpdateOn = DateTime.Now }); context.SaveChanges();
                context.Add(new Candidate { Email = "odin@mail.com", FirstName = "Odin", LastName = "FatherOfAll", IdExperience = 1, IsArchived = false, Phone = "067683997", UpdateOn = DateTime.Now }); context.SaveChanges();
            }
        }

    }
}
