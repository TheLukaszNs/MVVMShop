using Microsoft.EntityFrameworkCore;

namespace MVVMShop.DB.DbContexts;

public class MVVMShopContextFactory
{
    private readonly string _connectionString;

    public MVVMShopContextFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public MVVMShopContext CreateDbContext()
    {
        var serverVersion = ServerVersion.AutoDetect(_connectionString);
        DbContextOptions options = new DbContextOptionsBuilder().UseMySql(_connectionString, serverVersion)
            .Options;

        return new MVVMShopContext(options);
    }
}