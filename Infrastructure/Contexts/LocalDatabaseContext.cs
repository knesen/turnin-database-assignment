
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Contexts;

public partial class LocalDatabaseContext(DbContextOptions<LocalDatabaseContext> options) : DbContext(options)
{

    public virtual DbSet<ProductEntity> Products { get; set; }
    public virtual DbSet<CategoryEntity> Categories { get; set; }
    public virtual DbSet<OrderEntity> Orders { get; set; }
    public virtual DbSet<OrderRowEntity> OrderRows { get; set; }
    public virtual DbSet<AddressEntity> Addresses { get; set; }
    public virtual DbSet<CustomerEntity> Customers { get; set; }


}
