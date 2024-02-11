using Infrastructure.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DTOs;

public class OrderDTO
{
    public int OrderId { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<OrderRowEntity> OrderRows { get; set; } = new HashSet<OrderRowEntity>();

    public DateOnly CreatedAt { get; set; }

    public Guid CustomerId { get; set; }
    public virtual CustomerEntity Customer { get; set; } = null!;

}
