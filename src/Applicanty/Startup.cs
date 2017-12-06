using Applicanty.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Applicanty.Data.Services;
using Applicanty.Data.Repositories;
using Applicanty.Data.UnitOfWork.Interface;

namespace Applicanty
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<AtsDbContext>(optionsBuilder => optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserServices, UserSerices>();
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IExperienceService, ExperienceService>();
            services.AddScoped<ITechnologyService, TechnologyService>();
            services.AddScoped<IVacancyService, VacancyService>();
            services.AddScoped<IStasutService, StatusService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<IExperienceRepository, ExperienceRepository>();
            services.AddScoped<ITechnologyRepository, TechnologyRepository>();
            services.AddScoped<IVacancyRepository, VacancyRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();

            services.AddScoped<IUnitOfWork, IUnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
