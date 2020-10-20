using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Purefolio.DatabaseContext;
using Purefolio_backend.Services;

namespace Purefolio_backend
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.AddDbContext<DatabaseContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("Development"))
      );
      services.AddScoped<BaseDataService>();
      services.AddScoped<DatabaseStore>();
      services.AddTransient<IDatabaseStore, DatabaseStore>();
      services.AddScoped<EuroStatFetchService>();
      services.AddScoped<BaseData>();
      services.AddScoped<JSONConverter>();
      services.AddHttpClient();
      services.AddCors(options => options.AddPolicy("AllowAnyPolicy", builder =>
      {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
      }));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(
      IApplicationBuilder app,
      IWebHostEnvironment env,
      ILoggerFactory loggerFactory
    )
    {
      app.UseRouting();
      
      if (env.IsDevelopment())
      {
        app.UseCors("AllowAnyPolicy");
        app.UseDeveloperExceptionPage();
      }
      if (env.IsProduction() || env.IsStaging())
      {
        app.UseExceptionHandler("/Error");
      }

      // TODO: Remove before release
      // Deleting and recreating Database on each boot
      if (env.IsProduction() || env.IsStaging())
      {
        using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope()) {
          var context = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
          context.Database.EnsureDeleted();
          context.Database.EnsureCreated();
          }
        // Populate database on startup
        using (var serviceScrope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
        {
          var service = serviceScrope.ServiceProvider.GetRequiredService<BaseDataService>();
          //service.PopulateDatabase();
        }
      }

      app.UseRouting();

      app.UseAuthorization();

      app
        .UseEndpoints(endpoints =>
        {
          endpoints.MapControllers();
        });
    }
  }
}
