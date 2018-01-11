using Applicanty.Core.Entities;
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
            var random = new Random();

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
                context.Roles.Add(new IdentityRole<int> { Name = "Admininstrator", NormalizedName = "admin" });
                context.Roles.Add(new IdentityRole<int> { Name = "HR", NormalizedName = "hr" });
                context.Roles.Add(new IdentityRole<int> { Name = "Recruiter", NormalizedName = "recruiter" });

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
                context.UserRoles.Add(new IdentityUserRole<int> { RoleId = context.Roles.FirstOrDefault(item => item.Name.Equals("Admininstrator")).Id, UserId = context.Users.FirstOrDefault(item => item.UserName.Equals("victor@mail.com")).Id });
                context.UserRoles.Add(new IdentityUserRole<int> { RoleId = context.Roles.FirstOrDefault(item => item.Name.Equals("Admininstrator")).Id, UserId = context.Users.FirstOrDefault(item => item.UserName.Equals("pashka@mail.com")).Id });
                context.UserRoles.Add(new IdentityUserRole<int> { RoleId = context.Roles.FirstOrDefault(item => item.Name.Equals("HR")).Id, UserId = context.Users.FirstOrDefault(item => item.UserName.Equals("batman@mail.com")).Id });
                context.UserRoles.Add(new IdentityUserRole<int> { RoleId = context.Roles.FirstOrDefault(item => item.Name.Equals("Recruiter")).Id, UserId = context.Users.FirstOrDefault(item => item.UserName.Equals("stepanchik@mail.com")).Id });
                context.UserRoles.Add(new IdentityUserRole<int> { RoleId = context.Roles.FirstOrDefault(item => item.Name.Equals("Recruiter")).Id, UserId = context.Users.FirstOrDefault(item => item.UserName.Equals("dudka27@mail.com")).Id });

                context.SaveChanges();
            }

            if (!context.Vacancies.Any())
            {

                for (int i = 0; i < 60; i++)
                {
                    context.Vacancies.Add(new Vacancy
                    {
                        CreatedOn = DateTime.Now.AddDays(-(Convert.ToDouble(random.Next(5, 30)) + random.NextDouble())),
                        ExperienceId = i % 3 + 1,
                        UserId = i % 3 + 1,
                        IsArchived = false,
                        MaxSalary = 300 + random.Next(50, 200),
                        MinSalary = 100 + random.Next(50, 200),
                        Title = "Lorem ipsum" + i,
                        UpdatedOn = DateTime.Now,
                        ProjectDescription = i + " Nunc finibus purus dui, vitae semper nisi cursus eget. Duis sed felis sit amet erat pretium auctor et eu ipsum. Nam venenatis auctor ex a sollicitudin.",
                        JobDescription = i + " Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla metus mauris, fermentum convallis interdum nec, semper at nulla. Sed quam massa, posuere vestibulum erat sed, interdum ornare diam.",
                        EndDate = DateTime.Now.AddDays(Convert.ToDouble(random.Next(5, 30)) + random.NextDouble())
                    });
                }
                context.SaveChanges();
            }

            if (!context.Candidates.Any())
            {
                string[] Names = new string[6] { "Clark", "Bruce", "Barry", "Nicolas", "Ihor", "Stephan" };
                string[] SurNames = new string[6] { "Kent", "Wayne", "Alien", "Kage", "Hubish", "Dali" };

                for (int i = 0; i < 60; i++)
                {
                    context.Add(new Candidate
                    {
                        FirstName = Names[random.Next(0, 5)],
                        Email = Names[random.Next(0, 5)] + "@gmail.com",
                        LastName = SurNames[random.Next(0, 5)],
                        ExperienceId = random.Next(1,4),
                        IsArchived = false,
                        Phone = "0634534599" + i,
                        Birthday = DateTime.Now.AddYears(random.Next(-20,-30)),
                        UpdateOn = DateTime.Now
                    });
                }

                context.SaveChanges();
            }
        }
    }
}