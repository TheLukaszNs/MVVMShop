using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MVVMShop.DAL.Repositories
{
    using Entities;

    internal static class ProductsRepository
    {
        #region Queries

        const string SELECT_ALL = "SELECT * FROM products";
        const string INSERT = "INSERT products VALUE";
        const string DELETE = "DELETE FROM products WHERE id=";

        #endregion

        #region Methods

        public static List<Products> GetProducts()
        {
            List<Products> products = new List<Products>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(SELECT_ALL, connection);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                    products.Add(new Products(reader));

                connection.Close();
            }

            return products;
        }

        public static bool AddProduct(Products product)
        {
            bool state = false;

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{INSERT} {product.Insert()}", connection);

                connection.Open();

                state = true;
                product.Id = (uint)command.LastInsertedId;

                connection.Close();
            }

            return state;
        }

        public static bool EditProduct(Products product, uint id)
        {
            bool state = false;

            using (var connection = DBConnection.Instance.Connection)
            {
                string MODIFY = $"UPDATE products " +
                    $"SET " +
                    $"product_name={product.ProductName}, " +
                    $"price={product.Price}, " +
                    $"availability={product.Availability}, " +
                    $"image={product.Image} " +
                    $"WHERE " +
                    $"id={id}";

                MySqlCommand command = new MySqlCommand(MODIFY, connection);

                connection.Open();

                if (command.ExecuteNonQuery() == 1)
                    state = true;

                connection.Close();
            }

            return state;
        }

        public static bool DeleteProduct(uint id)
        {
            bool state = false;

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DELETE}{id}", connection);

                connection.Open();

                if (command.ExecuteNonQuery() == 1)
                    state = true;

                connection.Close();
            }

            return state;
        }

        #endregion
    }
}
