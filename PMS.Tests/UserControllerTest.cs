using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PMS.ApplicationDomainLayer.UserModel;
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
    public class UserControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public UserControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        // Sprint III -- 3. Testcases for User api's - different scenarios valid and invalid
        [Fact]
        public async Task GetAll_ReturnsAllUsers()  //test naming convention
        {
            // AAA
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var dbCtxt = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                dbCtxt.Users.Add(new User { Id = 1, FirstName = "John", LastName = "Doe", Password = "jndoe", Email = "jd1234@gmail.com" });
                dbCtxt.Users.Add(new User { Id = 2, FirstName = "Peter", LastName = "Shaw", Password = "pshaw", Email = "shaw4567@gmail.com" });
                dbCtxt.Users.Add(new User { Id = 3, FirstName = "Mark", LastName = "Smith", Password = "heyy", Email = "ms@test.com" });
                dbCtxt.SaveChanges();
            }

            // Act
            var response = await _client.GetAsync("/api/User");

            // Assert
            response.EnsureSuccessStatusCode();
            var respStr = await response.Content.ReadAsStringAsync();

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            Assert.Contains("{\"id\":1,\"firstName\":\"John\",\"lastName\":\"Doe\",\"email\":\"jd1234@gmail.com\",\"password\":\"jndoe\"}", respStr);
            Assert.Contains("{\"id\":2,\"firstName\":\"Peter\",\"lastName\":\"Shaw\",\"email\":\"shaw4567@gmail.com\",\"password\":\"pshaw\"}", respStr);
            Assert.Contains("{\"id\":3,\"firstName\":\"Mark\",\"lastName\":\"Smith\",\"email\":\"ms@test.com\",\"password\":\"heyy\"}", respStr);
        }

        [Fact]
        public async Task GetById_ReturnsUser_WhenUserWithIdExists()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var dbCtxt = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                dbCtxt.Users.Add(new User { Id = 7, FirstName = "Annie", LastName = "Bob", Password = "annie1234", Email = "annie.bob@gmail.com" });
                dbCtxt.Users.Add(new User { Id = 8, FirstName = "Maria", LastName = "Jane", Password = "mj56", Email = "maria.jane@gmail.com" });
                dbCtxt.Users.Add(new User { Id = 11, FirstName = "Peter", LastName = "Lee", Password = "pl789", Email = "peter.lee@gmail.com" });
                dbCtxt.SaveChanges();
            }

            // Act
            var response = await _client.GetAsync("/api/User/8");

            // Assert
            response.EnsureSuccessStatusCode();
            var respStr = await response.Content.ReadAsStringAsync();

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            Assert.Equal("{\"id\":8,\"firstName\":\"Maria\",\"lastName\":\"Jane\",\"email\":\"maria.jane@gmail.com\",\"password\":\"mj56\"}", respStr);
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WhenUserWithIdDoesNotExist()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var dbCtxt = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                dbCtxt.Users.Add(new User { Id = 14, FirstName = "Peter", LastName = "James", Password = "james1234", Email = "peter.james@gmail.com" });
                dbCtxt.Users.Add(new User { Id = 15, FirstName = "Lucie", LastName = "Jane", Password = "lj56", Email = "lucie.j@test.com" });
                dbCtxt.SaveChanges();
            }

            // Act
            var response = await _client.GetAsync("/api/User/12");
            var respStr = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Equal($"No user with id : 12", respStr);
        }

        [Fact]
        public async Task DeleteById_DeletesUser_WhenUserWithIdExist()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var dbCtxt = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                dbCtxt.Users.Add(new User { Id = 16, FirstName = "Jane", LastName = "Paul", Password = "jp1234", Email = "jane.paul@gmail.com" });
                dbCtxt.Users.Add(new User { Id = 17, FirstName = "Lucie", LastName = "Mac", Password = "lmj56", Email = "lucie.mac@test.com" });
                dbCtxt.SaveChanges();
            }

            // Act
            var response = await _client.DeleteAsync("/api/User/16");
            var respStr = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("{\"id\":16,\"firstName\":\"Jane\",\"lastName\":\"Paul\",\"email\":\"jane.paul@gmail.com\",\"password\":\"jp1234\"}", respStr);
        }

        [Fact]
        public async Task DeleteById_ReturnsNotFound_WhenUserWithIdDoesNotExist()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var dbCtxt = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                dbCtxt.Users.Add(new User { Id = 18, FirstName = "Jane", LastName = "Smith", Password = "js1234", Email = "jane.smith@gmail.com" });
                dbCtxt.Users.Add(new User { Id = 19, FirstName = "Lucie", LastName = "Paul", Password = "lpj56", Email = "lucie.paul@test.com" });
                dbCtxt.SaveChanges();
            }

            // Act
            var response = await _client.DeleteAsync("/api/User/10");
            var respStr = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Equal($"No user with id : 10", respStr);
        }

        [Fact]
        public async Task UpdateById_UpdatesUserDetails_WhenUserWithIdExist()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var dbCtxt = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                dbCtxt.Users.Add(new User { Id = 20, FirstName = "Mary", LastName = "Kath", Password = "mk1234", Email = "mary.kath@gmail.com" });
                dbCtxt.Users.Add(new User { Id = 21, FirstName = "Harry", LastName = "Mike", Password = "hmj56", Email = "harry.mike@test.com" });
                dbCtxt.SaveChanges();
            }
            var body = new
            {
                Id = "20",
                FirstName = "Mary",
                LastName = "Kathe",
                Email = "mary.kathe@test.com",
                Password = "mk1234"
            };

            // Act
            var response = await _client.PutAsync("/api/User/20", new StringContent(JsonConvert.SerializeObject(body), Encoding.Default, "application/json"));

            // Assert
            response.EnsureSuccessStatusCode();
            var respStr = await response.Content.ReadAsStringAsync();

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            Assert.Equal("{\"id\":20,\"firstName\":\"Mary\",\"lastName\":\"Kathe\",\"email\":\"mary.kathe@test.com\",\"password\":\"mk1234\"}", respStr);
        }

        [Fact]
        public async Task Create_CreatesAndAddUser()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var dbCtxt = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                dbCtxt.Users.Add(new User { Id = 22, FirstName = "Larry", LastName = "Kath", Password = "lk1234", Email = "lary.kath@gmail.com" });
                dbCtxt.SaveChanges();
            }
            var newUser = new
            {
                Id = "23",
                FirstName = "Jane",
                LastName = "Keeth",
                Email = "jane.keeth@test.com",
                Password = "jk1234"
            };

            // Act
            var response = await _client.PostAsync("/api/User", new StringContent(JsonConvert.SerializeObject(newUser), Encoding.Default, "application/json"));

            // Assert
            response.EnsureSuccessStatusCode();
            var respStr = await response.Content.ReadAsStringAsync();

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            Assert.Equal("{\"id\":23,\"firstName\":\"Jane\",\"lastName\":\"Keeth\",\"email\":\"jane.keeth@test.com\",\"password\":\"jk1234\"}", respStr);
        }
    }
}
