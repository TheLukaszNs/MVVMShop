using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVVMShop.DAL.Entities;
using MVVMShop.DAL.Repositories;
using MVVMShop.DB.DbContexts;
using MVVMShop.DTOs;
using MVVMShop.Model;

namespace MVVMShop.Services.ProductRemover
{
    public class DbProductRemover : IProductRemover
    {
        private readonly MVVMShopContextFactory _dbContextFactory;

        public DbProductRemover(MVVMShopContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

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