using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.DAL.Entities;
using MVVMShop.DAL.Repositories;
using MVVMShop.Model;

namespace MVVMShop.Services.ProductEditor
{
    public class DbProductEditor : IProductEditor
    {
        private readonly BaseRepository<Products> _productRepository;

        public DbProductEditor(BaseRepository<Products> productRepository) => _productRepository = productRepository;

        public bool EditProduct(uint? productId)
        {
            return false;
            // var dbProduct = _productRepository.Get(Products.FromDatabaseReader);
            //
            // return _productRepository.Edit(productId,
            //     $"id={dbProduct.Id}, product_name={dbProduct.ProductName}, price={dbProduct.Price}");
        }
    }
}