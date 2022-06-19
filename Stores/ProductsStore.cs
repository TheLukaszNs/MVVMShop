using System;
using System.Collections.Generic;
using MVVMShop.Model;
using MVVMShop.Services.ProductCreators;
using MVVMShop.Services.ProductProviders;
using MVVMShop.Services.ProductEditor;
using MVVMShop.Services.ProductRemover;

namespace MVVMShop.Stores
{
    public class ProductsStore
    {
        private readonly IProductCreator _productCreator;
        private readonly IProductProvider _productProvider;
        private readonly IProductEditor _productEditor;
        private readonly IProductRemover _productRemover;

        public List<Product> Products { get; } = new List<Product>();

        public ProductsStore(IProductCreator productCreator, IProductProvider productProvider, IProductEditor productEditor, IProductRemover productRemover)
        {
            _productCreator = productCreator;
            _productProvider = productProvider;
            _productEditor = productEditor;
            _productRemover = productRemover;

            InitProducts();
        }

        public event Action<Product> ProductAdded;
        public event Action<Product> ProductRemoved;

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

        public void DeleteProduct(uint? productId)
        {
            if (!_productRemover.RemoveProduct(productId))
                return;

            Product p = Products.Find(x => x.Id == productId);
            Products.Remove(p);
            OnProductRemoved(p);
        }

        private void InitProducts()
        {
            Products.Clear();

            var products = _productProvider.GetAllProducts();

            if (products != null)
                Products.AddRange(products);
        }

        private void OnProductAdded(Product product) => ProductAdded?.Invoke(product);
        private void OnProductRemoved(Product product) => ProductRemoved?.Invoke(product);
    }
}