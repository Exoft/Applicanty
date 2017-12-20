﻿using Applicanty.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Applicanty.Data.Services;
using Applicanty.Data.Repositories;
using Applicanty.Data.UnitOfWork.Interface;
using Applicanty.Data.UnitOfWork.Services;
using Applicanty.API;
using Applicanty.Data.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.Extensions.Logging;

namespace Applicant.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddDbContext<AtsDbContext>(optionsBuilder => optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IExperienceService, ExperienceService>();
            services.AddScoped<ITechnologyService, TechnologyService>();
            services.AddScoped<IVacancyService, VacancyService>();
            services.AddScoped<IStatusService, StatusService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<IExperienceRepository, ExperienceRepository>();
            services.AddScoped<ITechnologyRepository, TechnologyRepository>();
            services.AddScoped<IVacancyRepository, VacancyRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton(Configuration);

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Applicanty" });
            });

            services.AddIdentity<User, IdentityRole<long>>()
                .AddEntityFrameworkStores<AtsDbContext>()
                .AddDefaultTokenProviders();

            // configure identity server with in-memory stores, keys, clients and scopes
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(AuthConfig.GetIdentityResources())
                .AddInMemoryApiResources(AuthConfig.GetApiResources())
                .AddInMemoryClients(AuthConfig.GetClients())
                .AddAspNetIdentity<User>();

            services.AddMvcCore()
                .AddAuthorization()
                .AddJsonFormatters();

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:8000";
                    options.RequireHttpsMetadata = false;

                    options.ApiName = "applicantyAPI";
                });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            app.UseCors(options => options.WithOrigins("http://localhost:8001").AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
                try
                {
                    var context = serviceProvider.GetRequiredService<AtsDbContext>();
                    var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

                    AtsDbInitializer.Initialize(context, userManager);
                }
                catch (Exception ex)
                {
                    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Applicanty");
            });

            app.UseIdentityServer();
            
            app.UseMvc();
        }
    }
}
