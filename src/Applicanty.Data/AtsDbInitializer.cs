using Applicanty.Data.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace Applicanty.Data
{
    public static class AtsDbInitializer
    {
        public static void Initialize(AtsDbContext context, UserManager<User> userManager)
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
                user1.PasswordHash = userManager.PasswordHasher.HashPassword(user1, "password");
                context.Users.Add(user1);
                
                var user2 = new User { AccessFailedCount = 0, Email = "pashka@mail.com", EmailConfirmed = true, IsArchived = false, UserName = "pashka@mail.com", LastName = "Zibrov", LockoutEnabled = false, PhoneNumber = "0986823454", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UpdatedOn = DateTime.Now };
                user2.PasswordHash = userManager.PasswordHasher.HashPassword(user2, "password");
                context.Users.Add(user2);

                var user3 = new User { AccessFailedCount = 0, Email = "batman@mail.com", EmailConfirmed = true, IsArchived = false, UserName = "batman@mail.com", LastName = "Wayne", LockoutEnabled = false, PhoneNumber = "0986833454", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UpdatedOn = DateTime.Now };
                user3.PasswordHash = userManager.PasswordHasher.HashPassword(user3, "password");
                context.Users.Add(user3);

                var user4 = new User { AccessFailedCount = 0, Email = "stepanchik@mail.com", EmailConfirmed = true, IsArchived = false, UserName = "stepanchik@mail.com", LastName = "Hiha", LockoutEnabled = false, PhoneNumber = "09868344544", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UpdatedOn = DateTime.Now };
                user4.PasswordHash = userManager.PasswordHasher.HashPassword(user4, "password");
                context.Users.Add(user4);

                var user5 = new User { AccessFailedCount = 0, Email = "dudka27@mail.com", EmailConfirmed = true, IsArchived = false, UserName = "dudka27@mail.com", LastName = "Hendrix", LockoutEnabled = false, PhoneNumber = "0986834544", PhoneNumberConfirmed = true, TwoFactorEnabled = false, UpdatedOn = DateTime.Now };
                user5.PasswordHash = userManager.PasswordHasher.HashPassword(user5, "password");
                context.Users.Add(user5);
                
                context.SaveChanges();
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
                context.Add(new Candidate { Email = "superman_duperman@mail.com", FirstName = "Clark", LastName = "Kent", IdExperience = 4, IsArchived = false, Phone = "06345345997", UpdateOn = DateTime.Now });
                context.Add(new Candidate { Email = "batman@mail.com", FirstName = "Bruce", LastName = "Wayne", IdExperience = 1, IsArchived = false, Phone = "06763454337", UpdateOn = DateTime.Now });
                context.Add(new Candidate { Email = "flash@mail.com", FirstName = "Barry", LastName = "Alan", IdExperience = 2, IsArchived = false, Phone = "0676834634", UpdateOn = DateTime.Now });
                context.Add(new Candidate { Email = "capitan_america@mail.com", FirstName = "Steve", LastName = "Rodgers", IdExperience = 4, IsArchived = false, Phone = "06745654997", UpdateOn = DateTime.Now });
                context.Add(new Candidate { Email = "hulk@mail.com", FirstName = "Bruce", LastName = "Banner", IdExperience = 3, IsArchived = false, Phone = "0676345697", UpdateOn = DateTime.Now });
                context.Add(new Candidate { Email = "thor@mail.com", FirstName = "Thor", LastName = "SunOfOdin", IdExperience = 3, IsArchived = false, Phone = "067233997", UpdateOn = DateTime.Now });
                context.Add(new Candidate { Email = "odin@mail.com", FirstName = "Odin", LastName = "FatherOfAll", IdExperience = 1, IsArchived = false, Phone = "067683997", UpdateOn = DateTime.Now });

                context.SaveChanges();
            }
        }
    }
}