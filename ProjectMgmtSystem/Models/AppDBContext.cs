using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ProjectMgmtSystem.Models.UserModel;
using ProjectMgmtSystem.Models.TaskModel;
using ProjectMgmtSystem.Models.ProjectModel;

namespace ProjectMgmtSystem.Models
{
    // 2. DbContext (Sprint II)
    public class AppDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task1> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DbSet<UserLogin> Logins { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 3. invoke data seeding from dbcontext (Sprint II)
            modelBuilder.Seed();
        }
    }
}
