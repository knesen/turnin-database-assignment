using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

[Index(nameof(CategoryName), IsUnique = true)]
public class CategoryEntity
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(20)")]
    public string CategoryName { get; set; } = null!;

    public virtual ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();
}


