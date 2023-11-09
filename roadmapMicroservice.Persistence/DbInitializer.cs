using Serilog;
using Microsoft.EntityFrameworkCore;
using Roadmap.Microservice.Core;

namespace Roadmap.Microservice.Persistence
{
  public class DbInitializer : IDbInitializer
  {
    private readonly IServiceScopeFactory _scopeFactory;

    public DbInitializer(IServiceScopeFactory scopeFactory)
    {
      this._scopeFactory = scopeFactory;
    }

    public void Initialize()
    {
      // using (var serviceScope = _scopeFactory.CreateScope())
      // {
      //   using (var context = serviceScope.ServiceProvider.GetService<TicketContext>())
      //   {
      //     context.Ticket.Migrate();
      //   }
      // }
    }

    public void SeedData()
    {
      using var serviceScope = _scopeFactory.CreateScope();
      using var ticketContext = serviceScope.ServiceProvider.GetService<TicketContext>();

      ticketContext.Database.EnsureCreated();
      if (!ticketContext.Ticket.Any())
      {
        Log.Information("No data for Ticket. Create demo data.");
        var parent = new Ticket()
        {
          Id = Guid.NewGuid(),
          Title = "111",
          Description = "111",
          CreatedDate = DateTime.Now,
          UpdatedDate = DateTime.Now.AddDays(10),
          Children = new List<Ticket>()
        };

        var children1 = new Ticket()
        {
          Id = Guid.NewGuid(),
          Title = "111",
          Description = "111",
          CreatedDate = DateTime.Now,
          UpdatedDate = DateTime.Now.AddDays(10),
          Parents = new List<Ticket>{
            parent,
          }
        };

        var children2 = new Ticket()
        {
          Id = Guid.NewGuid(),
          Title = "222",
          Description = "222",
          CreatedDate = DateTime.Now,
          UpdatedDate = DateTime.Now.AddDays(10),
          Parents = new List<Ticket>{
            parent,
          }
        };
        parent.Children.Append(children1);
        parent.Children.Append(children2);

        ticketContext.Ticket.Add(entity: parent);
        ticketContext.Ticket.Add(entity: children1);
        ticketContext.Ticket.Add(entity: children2);
        ticketContext.SaveChanges();
      }
    }
  }
}