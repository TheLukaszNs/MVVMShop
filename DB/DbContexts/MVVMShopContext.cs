using Microsoft.EntityFrameworkCore;
using MVVMShop.DAL.Entities;

namespace MVVMShop.DB.DbContexts;

public class MVVMShopContext : DbContext
{
    public MVVMShopContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Products> Products { get; set; }
}