using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.DAL.Entities;
using MVVMShop.DAL.Repositories;
using MVVMShop.Model;

namespace MVVMShop.Services.ProductCreators
{
    public class DbProductCreator : IProductCreator
    {
        private readonly BaseRepository<Products> _productRepository;

        public DbProductCreator(BaseRepository<Products> productRepository)
        {
            _productRepository = productRepository;
        }

        public bool CreateProduct(Product product)
        {
            var dbProduct = new Products(product.ProductName, product.Price, true, "");

            return _productRepository.Add(dbProduct, new Dictionary<string, string>
            {
                ["@ProductName"] = dbProduct.ProductName,
                ["@Price"] = dbProduct.Price.ToString(CultureInfo.InvariantCulture),
                ["@Availability"] = dbProduct.Availability ? "1" : "0",
                ["@Image"] = ""
            });
        }
    }
}