using Infrastructure.Entities;

namespace Infrastructure.DTOs;

public class CustomerDTO
{
    public Guid CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public Guid AddressId { get; set; }
    public virtual AddressEntity Address { get; set; } = null!;
}
