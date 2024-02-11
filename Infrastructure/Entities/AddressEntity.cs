using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class AddressEntity
{
    [Key]
    public Guid AddressId { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(20)")]
    public string StreetAddress { get; set; } = null!;

    [Required]
    [Column(TypeName = "varchar(6)")]
    public string ZipCode { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(20)")]
    public string City { get; set; } = null!;

   

}
