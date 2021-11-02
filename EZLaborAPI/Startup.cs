using EZLaborAPI.Accounts.Domain.Persistence.Repositories;
using EZLaborAPI.Accounts.Domain.Services;
using EZLaborAPI.Accounts.Persistence.Repositories;
using EZLaborAPI.Accounts.Services;
using EZLaborAPI.Commons.Domain.Persistence.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZLaborAPI
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

            services.AddControllers();

            // DbContext Configuration
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            // Dependency Injection Configuration
            services.AddScoped<IFreelancerRepository, FreelancerRepository>();
            services.AddScoped<IEmployerRepository, EmployerRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IProposalRepository, ProposalRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IFreelancerService, FreelancerService>();
            services.AddScoped<IEmployerService, EmployerService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IProposalService, ProposalService>();

            // Endpoints Case Conventions Configuration

            services.AddRouting(options => options.LowercaseUrls = true);

            // AutoMapper initialization
            services.AddAutoMapper(typeof(Startup));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PracticeAPI", Version = "v1" });
                c.EnableAnnotations();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EZLaborAPI v1"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
