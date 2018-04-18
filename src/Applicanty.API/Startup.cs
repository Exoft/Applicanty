using Applicanty.API;
using Applicanty.API.Helpers;
using Applicanty.Core.Data;
using Applicanty.Core.Entities;
using Applicanty.Core.Services;
using Applicanty.Data;
using Applicanty.Data.UnitOfWork.Services;
using Applicanty.Services.Abstract;
using Applicanty.Services.Services;
using AutoMapper;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Principal;

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

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IPrincipal>(
                provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);
            
            services.AddDbContext<AtsDbContext>(optionsBuilder => optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<ITechnologyService, TechnologyService>();
            services.AddScoped<IVacancyService, VacancyService>();
            services.AddScoped<IStatusService, StatusService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton(Configuration);
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

#if DEBUG
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Applicanty" });
            });
#endif

            services.AddIdentity<User, IdentityRole<int>>(conf =>
                {
                    conf.SignIn.RequireConfirmedEmail = true;
                })
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

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddIdentityServerAuthentication(options =>
                {
#if DEBUG
                    options.Authority = "http://localhost:8000";
#else
                    options.Authority = "https://applicanty-api.exoft.net";
#endif
                    options.RequireHttpsMetadata = false;

                    options.ApiName = "applicantyAPI";
                });

            services.AddAutoMapper(a => a.AddProfile(new Applicanty.Core.MappingProfile()));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            app.UseCors(options => options.WithOrigins("http://localhost:8001", "https://applicanty.exoft.net").AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                try
                {
                    var context = serviceProvider.GetRequiredService<AtsDbContext>();
                    var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

                    AtsDbInitializer.Initialize(context, userManager).Wait();
                }
                catch (Exception ex)
                {
                    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

#if DEBUG
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Applicanty");
            });
#endif

            app.UseIdentityServer();
            
            app.UseMvc();
        }
    }
}
