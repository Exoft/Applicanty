using Applicanty.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Applicant.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Use that method if you want to seed database
            //SeedDb(args);
            
            var host = new WebHostBuilder()
               .UseKestrel()
               .UseContentRoot(Directory.GetCurrentDirectory())
               .UseIISIntegration()
               .UseStartup<Startup>()
               .Build();

            host.Run();
        }

        // Only used by EF Tooling
        public static IWebHost BuildWebHost(string[] args) =>
             WebHost.CreateDefaultBuilder()
                .ConfigureAppConfiguration((ctx, cfg) =>
                {
                    cfg.SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("config.json", true) // require the json file!
                        .AddEnvironmentVariables();
                })
                .ConfigureLogging((ctx, logging) => { }) // No logging
                .UseStartup<Startup>()
                .UseSetting("DesignTime", "true")
                .Build();

        public static void SeedDb(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<AtsDbContext>();
                    AtsDbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }
    }
}
