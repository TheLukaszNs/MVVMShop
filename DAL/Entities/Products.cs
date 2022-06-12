using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MVVMShop.DAL.Entities
{
    public sealed class Products
    {
        #region Properties

        public uint? Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public bool Availability { get; set; }
        public string Image { get; set; }

        #endregion

        #region Constructors

        public Products(MySqlDataReader reader)
        {
            Id = uint.Parse(reader["id"].ToString());
            ProductName = reader["product_name"].ToString();
            Price = decimal.Parse(reader["price"].ToString());
            Availability = bool.Parse(reader["availability"].ToString());
            Image = reader["image"].ToString();
        }

        public Products(string productName, decimal price, bool availability, string image)
        {
            Id = null;
            ProductName = productName.Trim();
            Price = price;
            Availability = availability;
            Image = image.Trim();
        }

        public Products(Products product)
        {
            Id = product.Id;
            ProductName = product.ProductName;
            Price = product.Price;
            Availability = product.Availability;
            Image = product.Image;
        }

        #endregion

        #region Methods

        public string Insert() => $"(0, {ProductName}, {Price}, {Availability}, {Image})";

        public override string ToString() => $"{ProductName}, {Price}, {(Availability ? "Dostępny" : "Niedostępny")}";

        public override bool Equals(object obj)
        {
            var product = obj as Products;

            if (product is null)
                return false;

            if (ProductName.ToLower() != product.ProductName.ToLower())
                return false;

            if (Price != product.Price)
                return false;

            if (Image.ToLower() != product.Image.ToLower())
                return false;

            return true;
        }

        public override int GetHashCode() => base.GetHashCode();

        #endregion
    }
}
