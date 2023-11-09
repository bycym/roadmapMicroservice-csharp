using Roadmap.Microservice.Shared;

namespace Roadmap.Microservice.Core
{
  public interface ITicketService
  {
    Task<TicketDTO> CreateTicket(TicketDTO TicketDTO);
  }
}