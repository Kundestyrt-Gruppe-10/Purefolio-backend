using System;
using System.Data.Entity;
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

      host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host
        .CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((hostingContext, config) =>
        {
          var env = hostingContext.HostingEnvironment;
          config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
          config.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json");
        })
        .ConfigureWebHostDefaults(webBuilder =>
        {
          webBuilder.UseStartup<Startup>();
        });
  }
}
