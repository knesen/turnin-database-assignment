using Infrastructure.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DTOs;

public class OrderRowDTO
{
    public int OrderRowId { get; set; }

    public int OrderId { get; set; }
    public virtual OrderEntity Order { get; set; } = null!;

    public string OrderRowProductId { get; set; } = null!;
    public virtual ProductEntity Product { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal OrderRowPrice;
}
