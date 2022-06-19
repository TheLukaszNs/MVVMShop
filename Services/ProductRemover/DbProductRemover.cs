using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.DAL.Entities;
using MVVMShop.DAL.Repositories;
using MVVMShop.Model;

namespace MVVMShop.Services.ProductRemover
{
    public class DbProductRemover : IProductRemover
    {
        private readonly BaseRepository<Products> _productRepository;

        public DbProductRemover(BaseRepository<Products> productRepository) => _productRepository = productRepository;

        public bool RemoveProduct(uint? productId) => _productRepository.Delete(productId);
    }
}
