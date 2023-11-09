using System;
using Microsoft.EntityFrameworkCore;
using Roadmap.Microservice.Core;

namespace Roadmap.Microservice.Persistence
{
  public class TicketContext : DbContext
  {
    public TicketContext(DbContextOptions<TicketContext> options)
        : base(options)
    {
    }

    public DbSet<Ticket> Ticket { get; set; }
  }

}