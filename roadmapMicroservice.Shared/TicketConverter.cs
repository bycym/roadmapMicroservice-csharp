using Roadmap.Microservice.Core;

namespace Roadmap.Microservice.Shared
{
  public static class TicketConverter
  {
    public static Ticket ToBO(this TicketDTO dto)
    {
      return new Ticket()
      {
        Id = Guid.NewGuid(),
        Title = dto.Title,
        Description = dto.Description,
        CreatedDate = dto.CreatedDate,
        UpdatedDate = dto.UpdatedDate,
        Children = (IEnumerable<Ticket>)dto.Children,
        Parents = (IEnumerable<Ticket>)dto.Parents
      };
    }

    public static TicketDTO ToDTO(this Ticket bo)
    {
      return new TicketDTO()
      {
        Title = bo.Title,
        Description = bo.Description,
        CreatedDate = bo.CreatedDate,
        UpdatedDate = bo.UpdatedDate,
        Children = (IEnumerable<TicketDTO>)(bo.Children ?? new List<Ticket>()),
        Parents = (IEnumerable<TicketDTO>)(bo.Parents ?? new List<Ticket>())
      };
    }
  }
}
