
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

 

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<CategoryEntity>()
    //        .HasIndex(x => x.Name)
    //        .IsUnique();

    //    modelBuilder.Entity<ProductEntity>()
    //        .HasIndex(x => x.Id)
    //        .IsUnique();

    //    modelBuilder.Entity<CustomerEntity>()
    //        .HasIndex(x => x.Email)
    //        .IsUnique();

    //    modelBuilder.Entity<OrderEntity>()
    //        .HasIndex(x => x.Id)
    //        .IsUnique();

    //}
}
