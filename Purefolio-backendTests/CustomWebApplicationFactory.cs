using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Purefolio.DatabaseContext;
using Purefolio_backend;
using Purefolio_backend.Services;
using System;
using System.Linq;

namespace Purefolio_backendTests.IntegrationTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<DatabaseContext>));
                services.Remove(descriptor);
                services.AddLogging(builder => builder
                      .AddConsole()
                      .AddFilter(level => level >= LogLevel.Trace)
                );

                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                // Add a database context (AppDbContext) using an in-memory database for testing.
                services.AddDbContext<DatabaseContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryAppDb");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database contexts
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var appDb = scopedServices.GetRequiredService<DatabaseContext>();
                    var dataStore = scopedServices.GetRequiredService<DatabaseStore>();
                    var mockDataService = scopedServices.GetRequiredService<MockDataService>();
                    var mockData = scopedServices.GetRequiredService<MockData>();

                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    // Ensure the database is created.
                    appDb.Database.EnsureCreated();

                    try
                    {
                        // Populate database on startup
                        mockDataService.PopulateDatabase();
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred seeding the " +
                                      "database with test messages. Error: {ex.Message}");
                    }
                }
            });
        }
    }

    internal class AppDbContext
    {
    }
}
