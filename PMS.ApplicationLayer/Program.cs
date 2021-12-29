using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
    public class Program
    {
        public static void Main(string[] args)
        {
            var apiCaller = new ServiceCollection();
            apiCaller.AddDbContext<AppDBContext>().AddScoped<IGenericRepository<User>, UserService>().
                AddScoped<IGenericRepository<Project>, ProjectService>().
                AddScoped<IGenericRepository<Task1>, Task1Service>();

            var service = apiCaller.BuildServiceProvider();
            var _userRepo = service.GetService<IGenericRepository<User>>();
            var _projectRepo = service.GetService<IGenericRepository<Project>>();
            var _taskRepo = service.GetService<IGenericRepository<Task1>>();

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
