using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectMgmtSystem.Models;
using ProjectMgmtSystem.Models.UserModel;
using ProjectMgmtSystem.Models.ProjectModel;
using ProjectMgmtSystem.Models.TaskModel;
using Microsoft.EntityFrameworkCore;

namespace ProjectMgmtSystem
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

            // 2. injecting DB context (Sprint II)
            var connectionString = Configuration.GetConnectionString("Default");
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connectionString));

            // 3. Implemented DI : dependency injection for all services - User, Project, Task (Sprint I)
            services.AddScoped<IUserRepository, UserService>();
            services.AddScoped<IProjectRepository, ProjectService>();
            services.AddScoped<ITask1Repository, Task1Service>();

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
