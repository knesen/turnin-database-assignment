using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class OrderRowEntity
{
    [Key]
    public int OrderRowId { get; set; }

    [ForeignKey(nameof(OrderEntity))]
    public int OrderId { get; set; }
    public virtual OrderEntity Order { get; set; } = null!;

    [ForeignKey(nameof(ProductEntity))]
    public string OrderRowProductId { get; set; } = null!;
    public virtual ProductEntity Product { get; set; } = null!;

    [Required]
    [Column(TypeName = "int")]
    public int Quantity { get; set; }    

    [ForeignKey(nameof(ProductEntity))]
    [Column(TypeName = "money")]
    public decimal OrderRowPrice;
    
}
