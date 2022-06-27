using System;
using Microsoft.EntityFrameworkCore;
using MVVMShop.DB.DbContexts;
using MVVMShop.DTOs;

namespace MVVMShop.Services.ProductRemover
{
    public class DbProductRemover : IProductRemover
    {
        private readonly MVVMShopContextFactory _dbContextFactory;

        public DbProductRemover(MVVMShopContextFactory dbContextFactory) => _dbContextFactory = dbContextFactory;

        public bool RemoveProduct(Guid productId)
        {
            using var context = _dbContextFactory.CreateDbContext();

            var product = new ProductDTO { Id = productId };
            context.Entry(product)
                .State = EntityState.Deleted;

            try
            {
                context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}