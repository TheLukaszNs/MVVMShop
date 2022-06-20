using System;
using System.Collections.Generic;
using System.Diagnostics;
using MVVMShop.DTOs;
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

        public ProductsStore(IProductCreator productCreator, IProductProvider productProvider,
            IProductEditor productEditor, IProductRemover productRemover)
        {
            _productCreator = productCreator;
            _productProvider = productProvider;
            _productEditor = productEditor;
            _productRemover = productRemover;

            InitProducts();
        }

        public event Action<Product> ProductAdded;
        public event Action<Product> ProductRemoved;
        public event Action ProductChanged;

        public void AddProduct(Product product)
        {
            _productCreator.CreateProduct(product);

            Products.Add(product);
            OnProductAdded(product);
        }

        public void EditProduct(Guid productId, Product editedProduct)
        {
            var newProduct = _productEditor.EditProduct(productId, editedProduct);
            if (newProduct is null)
                return;

            var index = Products.FindIndex(x => x.Id == productId);
            Products[index] = newProduct;
            OnProductChanged();
        }

        public void DeleteProduct(Guid productId)
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
        private void OnProductChanged() => ProductChanged?.Invoke();
    }
}