using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.DAL.Entities;
using MVVMShop.DAL.Repositories;
using MVVMShop.DB.DbContexts;
using MVVMShop.DTOs;
using MVVMShop.Model;

namespace MVVMShop.Services.ProductEditor
{
    public class DbProductEditor : IProductEditor
    {
        private readonly MVVMShopContextFactory _dbContextFactory;

        public DbProductEditor(MVVMShopContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public Product EditProduct(Guid productId, Product editedProduct)
        {
            using var context = _dbContextFactory.CreateDbContext();

            var product = context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                return null;

            product.Price = editedProduct.Price;
            product.Availability = editedProduct.Availability;
            product.Points = editedProduct.Points;
            product.ProductName = editedProduct.ProductName;
            context.SaveChanges();

            return ToProduct(product);
        }

        public Product ToProduct(ProductDTO product) => new()
        {
            ProductName = product.ProductName,
            Price = product.Price,
            Availability = product.Availability,
            Id = product.Id,
            Points = product.Points,
        };
    }
}