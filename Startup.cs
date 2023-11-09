using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Roadmap.Microservice.Core;

namespace TaskManagementApp.Api
{
  public class Startup
  {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      // Add database context
      services.AddDbContext<DbContext>(options =>
      {
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
      });

      // Configure services from the application layer
      services.AddScoped<IWorkplaceService, WorkplaceService>();

      // Other services and configurations

      // Enable CORS if needed
      services.AddCors(options =>
      {
        options.AddPolicy("AllowAnyOrigin", builder =>
              {
                builder.AllowAnyOrigin()
                             .AllowAnyMethod()
                             .AllowAnyHeader();
              });
      });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
      }

      // Enable CORS if needed
      app.UseCors("AllowAnyOrigin");

      app.UseRouting();

      // Add routing for the API controller
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
