using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS.ApplicationDomainLayer.UserModel;
using PMS.ApplicationDomainLayer.ProjectModel;
using PMS.ApplicationDomainLayer.TaskModel;
using PMS.ApplicationDomainLayer;

namespace PMS.DataAccessLayer
{
    // (Sprint II) -- 3. Seed data to DB for user, project, task
    public static class ModelSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@test.com", Password = "jd1234" },
                new User() { Id = 2, FirstName = "John", LastName = "Skeet", Email = "john.skeet@test.com", Password = "js5678" },
                new User() { Id = 3, FirstName = "Mark", LastName = "Seeman", Email = "mark.seeman@test.com", Password = "ms1234" },
                new User() { Id = 4, FirstName = "Bob", LastName = "Martin", Email = "bob.martin@test.com", Password = "bm5678" }
            );
            modelBuilder.Entity<Project>().HasData(
                new Project() { Id = 1, Name = "TestProject1", Detail = "This is a test project", CreatedOn = DateTime.Now },
                new Project() { Id = 2, Name = "TestProject2", Detail = "This is a test project", CreatedOn = DateTime.Now },
                new Project() { Id = 3, Name = "TestProject3", Detail = "This is a test project", CreatedOn = DateTime.Now },
                new Project() { Id = 4, Name = "TestProject4", Detail = "This is a test project", CreatedOn = DateTime.Now }
            );
            modelBuilder.Entity<Task1>().HasData(
                new Task1() { Id = 1, ProjectId = 1, Status = 2, AssignedToUserId = 1, Detail = "This is a test task", CreatedOn = DateTime.Now },
                new Task1() { Id = 2, ProjectId = 1, Status = 3, AssignedToUserId = 2, Detail = "This is a test task", CreatedOn = DateTime.Now },
                new Task1() { Id = 3, ProjectId = 2, Status = 4, AssignedToUserId = 2, Detail = "This is a test task", CreatedOn = DateTime.Now }
            );
            modelBuilder.Entity<UserLogin>().HasData(
                new UserLogin { Username = "JohnDoe", Password = "jd1234" },
                new UserLogin { Username = "JohnSkeet", Password = "js5678" },
                new UserLogin { Username = "MarkSeeman", Password = "ms1234" },
                new UserLogin { Username = "BobMartin", Password = "bm5678" }
            );
        }
    }
}
