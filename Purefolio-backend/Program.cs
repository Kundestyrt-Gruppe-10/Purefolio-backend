using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Purefolio_backend.Models;

namespace Purefolio_backend
{
  public class Program
  {
    public static void Main(string[] args)
    {
      // Main application configurer
      var host =
        CreateHostBuilder(args)
          .ConfigureLogging((hostingContext, logging) =>
          {
            logging
              .AddConfiguration(hostingContext
                .Configuration
                .GetSection("Logging"));
            logging.AddConsole();
            logging.AddDebug();
            logging.AddEventSourceLogger();
          })
          .Build();

      // Logger for startup logging
      var logger = host.Services.GetRequiredService<ILogger<DatabaseStore>>();

      SeedDatabase (logger);

      host.Run();
    }

    // TODO: Move to seperate location
    private static void SeedDatabase(ILogger<DatabaseStore> logger)
    {
      // TODO: Rewrite this to a proper seed method
      try
      {
        var rp = new DatabaseStore(logger);
        var response =
          rp.AddOrUpdateNace(new Nace() { NaceCode = "NACE!", NaceId = 1 });
      }
      catch (Exception exception)
      {
        logger.LogError(exception.StackTrace);
      }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host
        .CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
          webBuilder.UseStartup<Startup>();
        });
  }
}
