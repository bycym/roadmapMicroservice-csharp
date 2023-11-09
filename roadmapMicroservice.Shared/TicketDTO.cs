namespace Roadmap.Microservice.Shared
{
  public class TicketDTO
  {
    public required string Title { get; set; }
    public required string Description { get; set; }
    public System.DateTime CreatedDate { get; set; }
    public System.DateTime UpdatedDate { get; set; }
    public IEnumerable<TicketDTO>? Children { get; set; }
    public IEnumerable<TicketDTO>? Parents { get; set; }
  }
}