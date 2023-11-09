using Roadmap.Microservice.Core;
using Roadmap.Microservice.Persistence;
using Roadmap.Microservice.Shared;

public class TicketService : ITicketService
{
  private readonly ITicketRepository _ticketRepository;

  public TicketService(ITicketRepository ticketRepository)
  {
    _ticketRepository = ticketRepository;
  }

  // public Task CompleteTask(int taskId)
  // {
  //     var task = _taskRepository.Get(taskId);
  //     if (task != null)
  //     {
  //         task.IsCompleted = true;
  //         _taskRepository.Update(task);
  //     }
  //     return task;
  // }

  public async Task<TicketDTO> CreateTicket(TicketDTO TicketDTO)
  {
    var ticket = TicketDTO.ToBO();
    return (await _ticketRepository.CreateTicketAsync(ticket)).ToDTO();
  }
}
