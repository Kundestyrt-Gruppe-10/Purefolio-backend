using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
      services.AddDbContext<DatabaseContext>();
      services.AddSingleton<MockDataService>();
      services.AddSingleton<DatabaseStore>();
      services.AddSingleton<EuroStatFetchService>();
      services.AddSingleton<MockData>();
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
      if (env.IsDevelopment())
      {
        app.UseCors("AllowAnyPolicy");
        app.UseDeveloperExceptionPage();
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
