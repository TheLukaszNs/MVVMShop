using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.DAL.Entities;

namespace MVVMShop.Model
{
    public class Product
    {
        public uint? Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public bool Availability { get; set; }
        public uint Points { get; set; }

        public Product()
        {
        }

        public Product(Products product)
        {
            Id = product.Id;
            ProductName = product.ProductName;
            Price = product.Price;
            Availability = product.Availability;
            Points = product.Points;
        }
    }
}