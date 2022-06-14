using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MVVMShop.DAL.Repositories
{
    using Entities;

    internal static class OrdersRepository
    {
        #region Queries

        const string SELECT_ALL = "SELECT * FROM orders";
        const string INSERT = "INSERT orders VALUE";
        const string DELETE = "DELETE FROM orders WHERE id=";

        #endregion

        #region Methods

        public static List<Orders> GetProducts()
        {
            List<Orders> orders = new List<Orders>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(SELECT_ALL, connection);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                    orders.Add(new Orders(reader));

                connection.Close();
            }

            return orders;
        }

        public static bool AddOrder(Orders orders)
        {
            bool state = false;

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{INSERT} {orders.Insert()}", connection);

                connection.Open();

                state = true;
                orders.Id = (uint)command.LastInsertedId;

                connection.Close();
            }

            return state;
        }

        // Can modify Status only
        public static bool EditOrder(Orders order, uint id)
        {
            bool state = false;

            using (var connection = DBConnection.Instance.Connection)
            {
                string MODIFY = $"UPDATE orders " +
                    $"SET " +
                    $"order_status={order.Status} " +
                    $"WHERE" +
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
