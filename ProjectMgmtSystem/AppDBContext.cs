using Microsoft.EntityFrameworkCore;
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
    // (Sprint II) -- 2. Create DbContext
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
            // (Sprint II) -- 3. invoke data seeding from dbcontext
            modelBuilder.Seed();
        }
    }
}
