using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.DAL.Entities;
using MVVMShop.DAL.Repositories;
using MVVMShop.DB.DbContexts;
using MVVMShop.DTOs;
using MVVMShop.Model;

namespace MVVMShop.Services.ProductCreators
{
    public class DbProductCreator : IProductCreator
    {
        private readonly MVVMShopContextFactory _dbContextFactory;

        public DbProductCreator(MVVMShopContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void CreateProduct(Product product)
        {
            using var context = _dbContextFactory.CreateDbContext();
            var productDto = ToProductDto(product);

            context.Products.Add(productDto);
            context.SaveChanges();
            product.Id = productDto.Id;
        }

        private ProductDTO ToProductDto(Product product) => new()
        {
            Availability = product.Availability,
            Points = product.Points,
            Image = "",
            Price = product.Price,
            ProductName = product.ProductName
        };
    }
}