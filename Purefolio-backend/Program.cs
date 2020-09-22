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

      host.Run();
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
