using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.Model;

namespace MVVMShop.Stores
{
    public class CartStore
    {
        public Dictionary<Product, uint> Products { get; set; }

        public CartStore() => Products = new();

        public void AddToCart(Product product)
        {
            if (Products.ContainsKey(product))
                Products[product]++;
            else
                Products.Add(product, 1);
        }

        public void RemoveFromCart(Product product)
        {
            if (Products[product] - 1 == 0)
                Products.Remove(product);
            else
                Products[product]--;
        }
    }
}
