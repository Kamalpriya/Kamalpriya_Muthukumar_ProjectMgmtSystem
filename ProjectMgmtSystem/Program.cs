using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectMgmtSystem.Models;
using ProjectMgmtSystem.Models.ProjectModel;
using ProjectMgmtSystem.Models.TaskModel;
using ProjectMgmtSystem.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMgmtSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 4. Call Repository methods from api end point at client
            var apiCaller = new ServiceCollection();
            apiCaller.AddDbContext<AppDBContext>().AddScoped<IUserRepository, UserService>().
                AddScoped<IProjectRepository, ProjectService>().
                AddScoped<ITask1Repository, Task1Service>();

            var service = apiCaller.BuildServiceProvider();
            var _userRepo = service.GetService<IUserRepository>();
            var _projectRepo = service.GetService<IProjectRepository>();
            var _taskRepo = service.GetService<ITask1Repository>();

            var userList = _userRepo.GetUserByIdAsync(1);
            

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
