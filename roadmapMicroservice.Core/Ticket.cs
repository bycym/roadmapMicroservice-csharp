using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Roadmap.Microservice.Core
{
  [Table("Ticket")]
  public class Ticket
  {
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public required Guid Id { get; set; }
    [Required]
    public required string Title { get; set; }
    [StringLength(225)]
    public required string Description { get; set; }

    [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public System.DateTime CreatedDate { get; set; }
    [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public System.DateTime UpdatedDate { get; set; }

    [InverseProperty("Ticket")]
    public IEnumerable<Ticket>? Children { get; set; }

    [InverseProperty("Ticket")]
    public IEnumerable<Ticket>? Parents { get; set; }
  }
}