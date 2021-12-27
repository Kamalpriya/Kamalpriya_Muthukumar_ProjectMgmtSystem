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
using PMS.ApplicationDomainLayer.ProjectModel;
using PMS.ApplicationDomainLayer.TaskModel;
using PMS.ApplicationDomainLayer.UserModel;
using PMS.DataAccessLayer;
using PMS.PersistenceLayer.Repository;
using PMS.PersistenceLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.ApplicationLayer
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

            // (Sprint II) -- 2. injecting DB context with in memory DB
            var connectionString = Configuration.GetConnectionString("Default");
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IGenericRepository<User>, UserService>();
            services.AddScoped<IGenericRepository<Project>, ProjectService>();
            services.AddScoped<IGenericRepository<Task1>, Task1Service>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjectMgmtSystem", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectMgmtSystem v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}