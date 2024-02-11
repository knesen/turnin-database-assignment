namespace Infrastructure.DTOs;

public class ProductDTO
{
    public string ProductId { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string CategoryName { get; set; } = null!;
}
