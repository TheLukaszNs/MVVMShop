using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.DAL.Entities;
using MVVMShop.DAL.Repositories;
using MVVMShop.Model;

namespace MVVMShop.Services.ProductProviders
{
    internal class DbProductProvider : IProductProvider
    {
        private readonly BaseRepository<Products> _productsRepository;

        public DbProductProvider(BaseRepository<Products> productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public List<Product> GetAllProducts()
        {
            var products = _productsRepository.Get(Products.FromDatabaseReader);
            if (products == null || products.Count == 0)
                return null;

            return products.Select(p => new Product(p))
                .ToList();
        }
    }
}