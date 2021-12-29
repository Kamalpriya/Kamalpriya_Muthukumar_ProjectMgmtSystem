using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PMS.ApplicationLayer;
using PMS.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Tests
{
    // Sprint III -- 2. Setup WebApplicationFactory for the test project
    public class PMSWebApplicationFactory<T> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<AppDBContext>));

                services.Remove(descriptor);

                var svcProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                services.AddDbContext<AppDBContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                    options.UseInternalServiceProvider(svcProvider);
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    //var scopedServices = scope.ServiceProvider;
                    //var db = scopedServices.GetRequiredService<AppDBContext>();
                    //var logger = scopedServices
                    //    .GetRequiredService<ILogger<PMSWebApplicationFactory<Startup>>>();

                    //db.Database.EnsureCreated();
                    using (var appContext = scope.ServiceProvider.GetRequiredService<AppDBContext>())
                    {
                        try
                        {
                            appContext.Database.EnsureDeleted();
                            appContext.Database.EnsureCreated();
                        }
                        catch (Exception)
                        {
                            
                        }
                    }
                }
            });
        }
    }
}
