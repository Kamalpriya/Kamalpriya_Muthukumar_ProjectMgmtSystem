using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProjectMgmtSystem.Models.UserModel
{
    public class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        //public UserDBContext() : base("DefaultConnection")
        //{

        //}

        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //           .SetBasePath(Directory.GetCurrentDirectory())
        //           .AddJsonFile("appsettings.json")
        //           .Build();
        //        var connectionString = configuration.GetConnectionString("ConnectionStrings");
        //        optionsBuilder.UseSqlServer(connectionString);
        //    }
        //}
    }
}
