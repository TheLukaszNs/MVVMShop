using Microsoft.EntityFrameworkCore;
using MVVMShop.DAL.Entities;
using MVVMShop.DTOs;

namespace MVVMShop.DB.DbContexts;

public class MVVMShopContext : DbContext
{
    public MVVMShopContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ProductDTO> Products { get; set; }
    public DbSet<UserDTO> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductDTO>()
            .Property(p => p.Price)
            .HasPrecision(9, 2);
        base.OnModelCreating(modelBuilder);
    }
}