using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PMS.ApplicationDomainLayer.ProjectModel;
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
    public class ProjectControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public ProjectControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        // Sprint III -- 3. Testcases for Project api's - different scenarios valid and invalid
        [Fact]
        public async Task GetAll_ReturnsAllProjects()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var dbCtxt = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                dbCtxt.Projects.Add(new Project { Id = 1, Name = "TestProj1", Detail = "test project 1"});
                dbCtxt.Projects.Add(new Project { Id = 2, Name = "TestProj2", Detail = "test project 2"});
                dbCtxt.SaveChanges();
            }

            // Act
            var response = await _client.GetAsync("/api/Project");

            // Assert
            response.EnsureSuccessStatusCode();
            var respStr = await response.Content.ReadAsStringAsync();

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            Assert.Contains("{\"id\":1,\"name\":\"TestProj1\",\"detail\":\"test project 1\",\"createdOn\":\"0001-01-01T00:00:00\"}", respStr);
            Assert.Contains("{\"id\":2,\"name\":\"TestProj2\",\"detail\":\"test project 2\",\"createdOn\":\"0001-01-01T00:00:00\"}", respStr);
        }

        [Fact]
        public async Task GetById_ReturnsProject_WhenProjectWithIdExists()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var dbCtxt = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                dbCtxt.Projects.Add(new Project { Id = 3, Name = "TestProj3", Detail = "test project 3" });
                dbCtxt.Projects.Add(new Project { Id = 4, Name = "TestProj4", Detail = "test project 4" });
                dbCtxt.SaveChanges();
            }

            // Act
            var response = await _client.GetAsync("/api/Project/3");

            // Assert
            response.EnsureSuccessStatusCode();
            var respStr = await response.Content.ReadAsStringAsync();

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            Assert.Equal("{\"id\":3,\"name\":\"TestProj3\",\"detail\":\"test project 3\",\"createdOn\":\"0001-01-01T00:00:00\"}", respStr);
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WhenProjectWithIdDoesNotExist()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var dbCtxt = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                dbCtxt.Projects.Add(new Project { Id = 5, Name = "TestProj5", Detail = "test project 5" });
                dbCtxt.Projects.Add(new Project { Id = 6, Name = "TestProj6", Detail = "test project 6" });
                dbCtxt.SaveChanges();
            }

            // Act
            var response = await _client.GetAsync("/api/Project/7");
            var respStr = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Equal($"No project with id : 7", respStr);
        }

        [Fact]
        public async Task DeleteById_DeletesProject_WhenProjectWithIdExist()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var dbCtxt = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                dbCtxt.Projects.Add(new Project { Id = 8, Name = "TestProj8", Detail = "test project 8" });
                dbCtxt.Projects.Add(new Project { Id = 9, Name = "TestProj9", Detail = "test project 9" });
                dbCtxt.SaveChanges();
            }

            // Act
            var response = await _client.DeleteAsync("/api/Project/8");
            var respStr = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("{\"id\":8,\"name\":\"TestProj8\",\"detail\":\"test project 8\",\"createdOn\":\"0001-01-01T00:00:00\"}", respStr);
        }

        [Fact]
        public async Task DeleteById_ReturnsNotFound_WhenProjectWithIdDoesNotExist()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var dbCtxt = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                dbCtxt.Projects.Add(new Project { Id = 10, Name = "TestProj10", Detail = "test project 10" });
                dbCtxt.Projects.Add(new Project { Id = 11, Name = "TestProj11", Detail = "test project 11" });
                dbCtxt.SaveChanges();
            }

            // Act
            var response = await _client.DeleteAsync("/api/Project/12");
            var respStr = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Equal($"No project with id : 12", respStr);
        }

        [Fact]
        public async Task Update_UpdatesProjectDetails_WhenProjectWithIdExist()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var dbCtxt = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                dbCtxt.Projects.Add(new Project { Id = 13, Name = "TestProj13", Detail = "test project 13" });
                dbCtxt.Projects.Add(new Project { Id = 14, Name = "TestProj14", Detail = "test project 14" }); 
                dbCtxt.SaveChanges();
            }
            var newProj = new
            {
                Id = "14",
                Name = "TestProj14_Updated",
                Detail = "test project 14 updated",
            };

            // Act
            var response = await _client.PutAsync("/api/Project/14", new StringContent(JsonConvert.SerializeObject(newProj), Encoding.Default, "application/json"));

            // Assert
            response.EnsureSuccessStatusCode();
            var respStr = await response.Content.ReadAsStringAsync();

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            Assert.Equal("{\"id\":14,\"name\":\"TestProj14_Updated\",\"detail\":\"test project 14 updated\",\"createdOn\":\"0001-01-01T00:00:00\"}", respStr);
        }

        [Fact]
        public async Task Create_CreatesAndAddProject()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var dbCtxt = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                dbCtxt.Projects.Add(new Project { Id = 15, Name = "TestProj15", Detail = "test project 15" });
                dbCtxt.SaveChanges();
            }
            var newProj = new
            {
                Id = "16",
                Name = "TestProj16",
                Detail = "test project 16",
            };

            // Act
            var response = await _client.PostAsync("/api/Project", new StringContent(JsonConvert.SerializeObject(newProj), Encoding.Default, "application/json"));

            // Assert
            response.EnsureSuccessStatusCode();
            var respStr = await response.Content.ReadAsStringAsync();

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            Assert.Equal("{\"id\":16,\"name\":\"TestProj16\",\"detail\":\"test project 16\",\"createdOn\":\"0001-01-01T00:00:00\"}", respStr);
        }
    }
}
