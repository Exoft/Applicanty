using Applicanty.Data.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Applicanty.Data
{
    public static class AtsDbInitializer
    {
        public static async Task Initialize(AtsDbContext context, UserManager<User> userManager)
        {
            context.Database.EnsureCreated();

            if (!context.Experiences.Any())
            {
                context.Experiences.Add(new Experience { Name = "Senior" });
                context.Experiences.Add(new Experience { Name = "Middle" });
                context.Experiences.Add(new Experience { Name = "Junior" });
                context.Experiences.Add(new Experience { Name = "Trainee" });

                context.SaveChanges();
            }

            if (!context.Statuses.Any())
            {
                context.Add(new Status { Name = "To process", IsArchived = false });
                context.Add(new Status { Name = "Selected", IsArchived = false });
                context.Add(new Status { Name = "Contacted", IsArchived = false });
                context.Add(new Status { Name = "Not interested in this time", IsArchived = false });
                context.Add(new Status { Name = "Interviewed", IsArchived = false });
                context.Add(new Status { Name = "Rejected", IsArchived = false });
                context.Add(new Status { Name = "Offer Sent", IsArchived = false });
                context.Add(new Status { Name = "Declined offer", IsArchived = false });
                context.Add(new Status { Name = "Hired", IsArchived = false });
                context.Add(new Status { Name = "Keep in the pool", IsArchived = false });
                context.Add(new Status { Name = "Worked at Exoft", IsArchived = false });

                context.SaveChanges();
            }

            if (!context.Technologies.Any())
            {
                context.Add(new Technology { Name = "ASP.Net" });
                context.Add(new Technology { Name = "MS SQL" });
                context.Add(new Technology { Name = "Angular" });
                context.Add(new Technology { Name = "Bootstrap" });
                context.Add(new Technology { Name = "HTML" });
                context.Add(new Technology { Name = "CSS3" });

                context.SaveChanges();
            }

            if (!context.Roles.Any())
            {
                context.Roles.Add(new IdentityRole<long> { Name = "Admininstrator", NormalizedName = "admin" });
                context.Roles.Add(new IdentityRole<long> { Name = "HR", NormalizedName = "hr" });
                context.Roles.Add(new IdentityRole<long> { Name = "Recruiter", NormalizedName = "recruiter" });

                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                var user1 = new User { AccessFailedCount = 0, Email = "victor@mail.com", EmailConfirmed = true, IsArchived = false, UserName = "victor@mail.com", LastName = "Pavlik", LockoutEnabled = false, PhoneNumber = "0985434944", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UpdatedOn = DateTime.Now };
                await userManager.CreateAsync(user1, "Rerehelpf1@");

                var user2 = new User { AccessFailedCount = 0, Email = "pashka@mail.com", EmailConfirmed = true, IsArchived = false, UserName = "pashka@mail.com", LastName = "Zibrov", LockoutEnabled = false, PhoneNumber = "0986823454", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UpdatedOn = DateTime.Now };
                await userManager.CreateAsync(user2, "Rerehelpf1@");

                var user3 = new User { AccessFailedCount = 0, Email = "batman@mail.com", EmailConfirmed = true, IsArchived = false, UserName = "batman@mail.com", LastName = "Wayne", LockoutEnabled = false, PhoneNumber = "0986833454", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UpdatedOn = DateTime.Now };
                await userManager.CreateAsync(user3, "Rerehelpf1@");

                var user4 = new User { AccessFailedCount = 0, Email = "stepanchik@mail.com", EmailConfirmed = true, IsArchived = false, UserName = "stepanchik@mail.com", LastName = "Hiha", LockoutEnabled = false, PhoneNumber = "09868344544", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UpdatedOn = DateTime.Now };
                await userManager.CreateAsync(user4, "Rerehelpf1@");

                var user5 = new User { AccessFailedCount = 0, Email = "dudka27@mail.com", EmailConfirmed = true, IsArchived = false, UserName = "dudka27@mail.com", LastName = "Hendrix", LockoutEnabled = false, PhoneNumber = "0986834544", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UpdatedOn = DateTime.Now };
                await userManager.CreateAsync(user5, "Rerehelpf1@");
            }

            if (!context.UserRoles.Any())
            {
                context.UserRoles.Add(new IdentityUserRole<long> { RoleId = context.Roles.FirstOrDefault(item => item.Name.Equals("Admininstrator")).Id, UserId = context.Users.FirstOrDefault(item => item.UserName.Equals("victor@mail.com")).Id });
                context.UserRoles.Add(new IdentityUserRole<long> { RoleId = context.Roles.FirstOrDefault(item => item.Name.Equals("Admininstrator")).Id, UserId = context.Users.FirstOrDefault(item => item.UserName.Equals("pashka@mail.com")).Id });
                context.UserRoles.Add(new IdentityUserRole<long> { RoleId = context.Roles.FirstOrDefault(item => item.Name.Equals("HR")).Id, UserId = context.Users.FirstOrDefault(item => item.UserName.Equals("batman@mail.com")).Id });
                context.UserRoles.Add(new IdentityUserRole<long> { RoleId = context.Roles.FirstOrDefault(item => item.Name.Equals("Recruiter")).Id, UserId = context.Users.FirstOrDefault(item => item.UserName.Equals("stepanchik@mail.com")).Id });
                context.UserRoles.Add(new IdentityUserRole<long> { RoleId = context.Roles.FirstOrDefault(item => item.Name.Equals("Recruiter")).Id, UserId = context.Users.FirstOrDefault(item => item.UserName.Equals("dudka27@mail.com")).Id });

                context.SaveChanges();
            }

            if (!context.Vacancies.Any())
            {
                context.Vacancies.Add(new Vacancy
                {
                    CreatedOn = DateTime.Now,
                    ExperienceId = 1,
                    UserId = 1,
                    IsArchived = false,
                    MaxSalary = 300,
                    MinSalary = 250,
                    Title = "Lorem ipsum",
                    UpdatedOn = DateTime.Now,
                    ProjectDescription = "Nunc finibus purus dui, vitae semper nisi cursus eget. Duis sed felis sit amet erat pretium auctor et eu ipsum. Nam venenatis auctor ex a sollicitudin.",
                    JobDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla metus mauris, fermentum convallis interdum nec, semper at nulla. Sed quam massa, posuere vestibulum erat sed, interdum ornare diam.",
                });

                context.Vacancies.Add(new Vacancy
                {
                    CreatedOn = DateTime.Now,
                    ExperienceId = 2,
                    UserId = 2,
                    IsArchived = false,
                    MaxSalary = 400,
                    MinSalary = 150,
                    Title = "Lorem ipsum",
                    UpdatedOn = DateTime.Now,
                    ProjectDescription = "Nunc finibus purus dui, vitae semper nisi cursus eget. Duis sed felis sit amet erat pretium auctor et eu ipsum. Nam venenatis auctor ex a sollicitudin.",
                    JobDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla metus mauris, fermentum convallis interdum nec, semper at nulla. Sed quam massa, posuere vestibulum erat sed, interdum ornare diam.",
                });

                context.Vacancies.Add(new Vacancy
                {
                    CreatedOn = DateTime.Now,
                    ExperienceId = 3,
                    UserId = 3,
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
                context.Add(new Candidate { Email = "superman_duperman@mail.com", FirstName = "Clark", LastName = "Kent", ExperienceId = 4, IsArchived = false, Phone = "06345345997", UpdateOn = DateTime.Now });
                context.Add(new Candidate { Email = "batman@mail.com", FirstName = "Bruce", LastName = "Wayne", ExperienceId = 1, IsArchived = false, Phone = "06763454337", UpdateOn = DateTime.Now });
                context.Add(new Candidate { Email = "flash@mail.com", FirstName = "Barry", LastName = "Alan", ExperienceId = 2, IsArchived = false, Phone = "0676834634", UpdateOn = DateTime.Now });
                context.Add(new Candidate { Email = "capitan_america@mail.com", FirstName = "Steve", LastName = "Rodgers", ExperienceId = 4, IsArchived = false, Phone = "06745654997", UpdateOn = DateTime.Now });
                context.Add(new Candidate { Email = "hulk@mail.com", FirstName = "Bruce", LastName = "Banner", ExperienceId = 3, IsArchived = false, Phone = "0676345697", UpdateOn = DateTime.Now });
                context.Add(new Candidate { Email = "thor@mail.com", FirstName = "Thor", LastName = "SunOfOdin", ExperienceId = 3, IsArchived = false, Phone = "067233997", UpdateOn = DateTime.Now });
                context.Add(new Candidate { Email = "odin@mail.com", FirstName = "Odin", LastName = "FatherOfAll", ExperienceId = 1, IsArchived = false, Phone = "067683997", UpdateOn = DateTime.Now });

                context.SaveChanges();
            }
        }
    }
}