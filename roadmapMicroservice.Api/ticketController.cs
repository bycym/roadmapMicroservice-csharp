using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Roadmap.Microservice.Core;
using Roadmap.Microservice.Shared;


namespace Roadmap.Microservice.Api
{
  [ApiController]
  [Route("api/tickets")]
  public class TicketController : ControllerBase
  {
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
      _ticketService = ticketService;
    }

    [HttpPost]
    public IActionResult CreateTicket([FromBody] TicketDTO ticketDTO)
    {
      var ticket = _ticketService.CreateTicket(ticketDTO);
      return Created($"/api/Tickets/{ticket.Id}", ticket);
    }
  }
}