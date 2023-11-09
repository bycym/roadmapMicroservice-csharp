using Roadmap.Microservice.Core;

namespace Roadmap.Microservice.Persistence
{
  public class TicketRepository : ITicketRepository
  {
    private readonly TicketContext _context;

    public TicketRepository(TicketContext context)
    {
      _context = context;
    }

    public async Task<Ticket> CreateTicketAsync(Ticket ticket)
    {
      // _context.Ticket.Add(Ticket);
      // await _context.SaveChangesAsync();
      return ticket;
      throw new NotImplementedException();

    }

    public async Task DeleteTicketAsync(int ticketId)
    {
      // var ticket = await _context.Ticket.FindAsync(TicketId);
      // if (Ticket != null)
      // {
      //   _context.Ticket.Remove(Ticket);
      //   await _context.SaveChangesAsync();
      // }
      throw new NotImplementedException();

    }

    public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
    {
      throw new NotImplementedException();
    }

    public async Task<Ticket> GetTaskByIdAsync(int ticketId)
    {
      throw new NotImplementedException();
    }

    public async Task<Ticket> UpdateTicketAsync(Ticket ticket)
    {
      throw new NotImplementedException();
    }

    // Implement other repository methods (Get, Update, etc.)
  }
}