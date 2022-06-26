using Microsoft.EntityFrameworkCore;
using MVVMShop.DTOs;

namespace MVVMShop.DB.DbContexts;

public class MVVMShopContext : DbContext
{
    public MVVMShopContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ProductDTO> Products { get; set; }
    public DbSet<UserDTO> Users { get; set; }
    public DbSet<OrderDTO> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductDTO>()
            .Property(p => p.Price)
            .HasPrecision(9, 2);

        modelBuilder.Entity<OrderDTO>()
            .Property(o => o.Value)
            .HasPrecision(10, 2);

        modelBuilder.Entity<ProductDTO>()
            .HasMany(p => p.OrdersProducts)
            .WithOne(op => op.Product)
            .IsRequired()
            .HasForeignKey(op => op.ProductId);

        modelBuilder.Entity<OrderDTO>()
            .HasMany(o => o.OrdersProducts)
            .WithOne(op => op.Order)
            .IsRequired()
            .HasForeignKey(op => op.OrderId);

        base.OnModelCreating(modelBuilder);
    }
}