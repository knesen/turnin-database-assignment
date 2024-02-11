using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

[Index(nameof(OrderId), IsUnique = true)]
public class OrderEntity
{
    [Key]
    public int OrderId { get; set; }
        
    [Column(TypeName = "varchar(10)")]
    public string? Status { get; set; }

    public virtual ICollection<OrderRowEntity> OrderRows { get; set; } = new HashSet<OrderRowEntity>();

    [Required]
    public DateOnly CreatedAt { get; set; }

    [Required]
    [ForeignKey(nameof(CustomerEntity))]
    public Guid CustomerId { get; set; }
    public virtual CustomerEntity Customer { get; set; } = null!;

}
