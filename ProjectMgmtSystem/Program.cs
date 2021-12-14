using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectMgmtSystem.Models.ProjectModel;
using ProjectMgmtSystem.Models.TaskModel;
using ProjectMgmtSystem.Models.UserModel;
using ProjectMgmtSystem.Repository;
using ProjectMgmtSystem.Service;
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
            // (Sprint II) -- 4. Call Repository methods from api end point at client
            var apiCaller = new ServiceCollection();
            apiCaller.AddDbContext<AppDBContext>().AddScoped<IGenericRepository<User>, UserService>().
                AddScoped<IGenericRepository<Project>, ProjectService>().
                AddScoped<IGenericRepository<Task1>, Task1Service>();

            var service = apiCaller.BuildServiceProvider();
            var _userRepo = service.GetService <IGenericRepository<User>>();
            var _projectRepo = service.GetService <IGenericRepository<Project>>();
            var _taskRepo = service.GetService <IGenericRepository<Task1>>();

            // invoke repository method
            var userList = _userRepo.GetAllAsync();
            
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
