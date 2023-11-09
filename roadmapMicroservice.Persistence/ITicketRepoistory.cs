using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Roadmap.Microservice.Core;

namespace Roadmap.Microservice.Persistence
{
  public interface ITicketRepository
  {
    Task<Ticket> GetTaskByIdAsync(int ticketId);
    Task<IEnumerable<Ticket>> GetAllTicketsAsync();
    Task<Ticket> CreateTicketAsync(Ticket ticket);
    Task<Ticket> UpdateTicketAsync(Ticket ticket);
    Task DeleteTicketAsync(int ticketId);
  }
}