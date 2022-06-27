using System;
using System.Collections.Generic;
using System.Linq;
using MVVMShop.Common.HelperTypes;
using MVVMShop.Model;
using MVVMShop.Services.OrderCreators;

namespace MVVMShop.Stores
{
    public class CartStore
    {
        private readonly IOrderCreator _orderCreator;

        public Dictionary<Product, uint> Products { get; set; }

        public uint TotalPoints => (uint)Products.Sum(p => p.Key.Points * p.Value);
        public decimal TotalPrice => Products.Sum(p => p.Key.Price * p.Value);

        public CartStore(IOrderCreator orderCreator)
        {
            _orderCreator = orderCreator;
            Products = new Dictionary<Product, uint>();
        }

        public void AddToCart(Product product)
        {
            if (Products.ContainsKey(product))
                Products[product]++;
            else
                Products.Add(product, 1);

            OnCartUpdated();
        }

        public void RemoveFromCart(Product product)
        {
            if (Products[product] - 1 == 0)
                Products.Remove(product);
            else
                Products[product]--;

            OnCartUpdated();
        }

        public void ClearCart() => Products.Clear();  

        public event Action CartUpdated;

        protected virtual void OnCartUpdated() => CartUpdated?.Invoke();

        public void Finalize(OrderMetadata metadata) => _orderCreator.CreateOrder(metadata, Products);
    }
}