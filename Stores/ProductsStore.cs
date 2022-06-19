using System;
using System.Collections.Generic;
using MVVMShop.Model;
using MVVMShop.Services.ProductCreators;
using MVVMShop.Services.ProductProviders;

namespace MVVMShop.Stores
{
    public class ProductsStore
    {
        private readonly IProductCreator _productCreator;
        private readonly IProductProvider _productProvider;
        public List<Product> Products { get; } = new List<Product>();

        public ProductsStore(IProductCreator productCreator, IProductProvider productProvider)
        {
            _productCreator = productCreator;
            _productProvider = productProvider;
            InitProducts();
        }

        public event Action<Product> ProductAdded;

        public void AddProduct(Product product)
        {
            if (!_productCreator.CreateProduct(product))
                return;

            Products.Add(product);
            OnProductAdded(product);
        }

        public void EditProduct(uint? productId)
        {

        }

        private void InitProducts()
        {
            Products.Clear();

            var products = _productProvider.GetAllProducts();

            if (products != null)
                Products.AddRange(products);
        }

        private void OnProductAdded(Product product) => ProductAdded?.Invoke(product);
    }
}