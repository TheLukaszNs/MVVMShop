using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.DB.DbContexts;
using MVVMShop.Model;

namespace MVVMShop.Services.ProductProviders
{
    internal class DbProductProvider : IProductProvider
    {
        private readonly MVVMShopContextFactory _dbContextFactory;

        public DbProductProvider(MVVMShopContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            using var context = _dbContextFactory.CreateDbContext();

            var products = context.Products.ToList();
            return products.Select(p => new Product
            {
                ProductName = p.ProductName,
                Price = p.Price,
                Availability = p.Availability,
                Id = p.Id,
                Points = p.Points,
            });
        }
    }
}