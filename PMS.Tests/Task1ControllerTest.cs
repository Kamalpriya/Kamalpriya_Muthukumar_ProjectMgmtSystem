using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PMS.ApplicationDomainLayer.TaskModel;
using PMS.ApplicationLayer;
using PMS.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

// Sprint III -- 1. Test project PMS.Tests using XUnit
namespace PMS.Tests
{
    // Sprint III -- 2. Configure test server using WebApplicationFactory
    public class Task1ControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public Task1ControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        // Sprint III -- 3. Testcases for Task api's - different scenarios valid and invalid
        [Fact]
        public async Task GetAll_ReturnsAllTasks()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var dbCtxt = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                dbCtxt.Tasks.Add(new Task1 { Id = 1, ProjectId = 1, Status = 2, AssignedToUserId = 1, Detail = "test task 1" });
                dbCtxt.Tasks.Add(new Task1 { Id = 2, ProjectId = 1, Status = 3, AssignedToUserId = 2, Detail = "test task 2" });
                dbCtxt.SaveChanges();
            }

            // Act
            var response = await _client.GetAsync("/api/Task1");

            // Assert
            response.EnsureSuccessStatusCode();
            var respStr = await response.Content.ReadAsStringAsync();

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            Assert.Contains("{\"id\":1,\"projectId\":1,\"status\":2,\"assignedToUserId\":1,\"detail\":\"test task 1\",\"createdOn\":\"0001-01-01T00:00:00\"}", respStr);
            Assert.Contains("{\"id\":2,\"projectId\":1,\"status\":3,\"assignedToUserId\":2,\"detail\":\"test task 2\",\"createdOn\":\"0001-01-01T00:00:00\"}", respStr);
        }

        [Fact]
        public async Task GetById_ReturnsTask_WhenTaskWithIdExists()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var dbCtxt = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                dbCtxt.Tasks.Add(new Task1 { Id = 3, ProjectId = 2, Status = 2, AssignedToUserId = 1, Detail = "test task 3" });
                dbCtxt.Tasks.Add(new Task1 { Id = 4, ProjectId = 3, Status = 3, AssignedToUserId = 2, Detail = "test task 4" });
                dbCtxt.SaveChanges();
            }

            // Act
            var response = await _client.GetAsync("/api/Task1/3");

            // Assert
            response.EnsureSuccessStatusCode();
            var respStr = await response.Content.ReadAsStringAsync();

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            Assert.Equal("{\"id\":3,\"projectId\":2,\"status\":2,\"assignedToUserId\":1,\"detail\":\"test task 3\",\"createdOn\":\"0001-01-01T00:00:00\"}", respStr);
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WhenTaskWithIdDoesNotExist()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var dbCtxt = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                dbCtxt.Tasks.Add(new Task1 { Id = 5, ProjectId = 2, Status = 2, AssignedToUserId = 1, Detail = "test task 5" });
                dbCtxt.Tasks.Add(new Task1 { Id = 6, ProjectId = 3, Status = 3, AssignedToUserId = 2, Detail = "test task 6" });
                dbCtxt.SaveChanges();
            }

            // Act
            var response = await _client.GetAsync("/api/Task1/7");
            var respStr = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Equal($"No task with id : 7", respStr);
        }

        [Fact]
        public async Task DeleteById_DeletesTask_WhenTaskWithIdExist()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var dbCtxt = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                dbCtxt.Tasks.Add(new Task1 { Id = 8, ProjectId = 2, Status = 2, AssignedToUserId = 1, Detail = "test task 8" });
                dbCtxt.Tasks.Add(new Task1 { Id = 9, ProjectId = 3, Status = 3, AssignedToUserId = 2, Detail = "test task 9" });
                dbCtxt.SaveChanges();
            }

            // Act
            var response = await _client.DeleteAsync("/api/Task1/9");
            var respStr = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("{\"id\":9,\"projectId\":3,\"status\":3,\"assignedToUserId\":2,\"detail\":\"test task 9\",\"createdOn\":\"0001-01-01T00:00:00\"}", respStr);
        }

        [Fact]
        public async Task DeleteById_ReturnsNotFound_WhenTaskWithIdDoesNotExist()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var dbCtxt = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                dbCtxt.Tasks.Add(new Task1 { Id = 10, ProjectId = 2, Status = 2, AssignedToUserId = 1, Detail = "test task 10" });
                dbCtxt.Tasks.Add(new Task1 { Id = 11, ProjectId = 3, Status = 3, AssignedToUserId = 2, Detail = "test task 11" });
                dbCtxt.SaveChanges();
            }

            // Act
            var response = await _client.DeleteAsync("/api/Task1/12");
            var respStr = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Equal($"No task with id : 12", respStr);
        }

        [Fact]
        public async Task Update_UpdatesTaskDetails_WhenTaskWithIdExist()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var dbCtxt = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                dbCtxt.Tasks.Add(new Task1 { Id = 13, ProjectId = 2, Status = 2, AssignedToUserId = 1, Detail = "test task 13" });
                dbCtxt.Tasks.Add(new Task1 { Id = 14, ProjectId = 3, Status = 2, AssignedToUserId = 2, Detail = "test task 14" });
                dbCtxt.SaveChanges();
            }
            var newProj = new
            {
                Id = "14",
                ProjectId = 3,
                Status = 3,
                AssignedToUserId = 1,
                Detail = "test task 14 updated"
            };

            // Act
            var response = await _client.PutAsync("/api/Task1/14", new StringContent(JsonConvert.SerializeObject(newProj), Encoding.Default, "application/json"));

            // Assert
            response.EnsureSuccessStatusCode();
            var respStr = await response.Content.ReadAsStringAsync();

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            Assert.Equal("{\"id\":14,\"projectId\":3,\"status\":3,\"assignedToUserId\":1,\"detail\":\"test task 14 updated\",\"createdOn\":\"0001-01-01T00:00:00\"}", respStr);
        }

        [Fact]
        public async Task Create_CreatesAndAddTask()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var dbCtxt = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                dbCtxt.Tasks.Add(new Task1 { Id = 15, ProjectId = 2, Status = 0, AssignedToUserId = 1, Detail = "test task 15" });
                dbCtxt.SaveChanges();
            }
            var newProj = new
            {
                Id = "16",
                ProjectId = 3,
                Status = 1,
                AssignedToUserId = 2,
                Detail = "test task 16"
            };

            // Act
            var response = await _client.PostAsync("/api/Task1", new StringContent(JsonConvert.SerializeObject(newProj), Encoding.Default, "application/json"));

            // Assert
            response.EnsureSuccessStatusCode();
            var respStr = await response.Content.ReadAsStringAsync();

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            Assert.Equal("{\"id\":16,\"projectId\":3,\"status\":1,\"assignedToUserId\":2,\"detail\":\"test task 16\",\"createdOn\":\"0001-01-01T00:00:00\"}", respStr);
        }
    }
}
