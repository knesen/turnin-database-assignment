using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

[Index(nameof(Email), IsUnique = true)]
[Index(nameof(CustomerId), IsUnique = true)]
public class CustomerEntity
{
    [Key]
    public Guid CustomerId { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(20)")]
    public string FirstName { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(20)")]
    public string LastName { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(20)")]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Email { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(AddressEntity))]
    public Guid AddressId { get; set; }
    public virtual AddressEntity Address { get; set; } = null!;
}
