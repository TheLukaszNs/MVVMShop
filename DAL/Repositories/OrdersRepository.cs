using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MVVMShop.DAL.Repositories
{
    using Entities;

    internal class OrdersRepository
    {
        #region Queries

        const string SELECT_ALL = "SELECT * FROM orders";
        const string INSERT = "INSERT orders VALUE";
        const string DELETE = "DELETE FROM orders WHERE id=";

        #endregion

        #region Properties

        private readonly DbConnection dbconnection;

        #endregion

        #region Constructors

        public OrdersRepository(DbConnection dbconnection) => this.dbconnection = dbconnection;

        #endregion

        #region Methods

        public List<Orders> GetOrders()
        {
            List<Orders> orders = new List<Orders>();

            using (var connection = dbconnection.Connection)
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

        public bool AddOrder(Orders order)
        {
            bool state = false;

            using (var connection = dbconnection.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{INSERT} {order.Insert()}", connection);

                connection.Open();

                state = true;
                order.Id = (uint)command.LastInsertedId;

                connection.Close();
            }

            return state;
        }

        // Can modify Status only
        public bool EditOrder(Orders order, uint id)
        {
            bool state = false;

            using (var connection = dbconnection.Connection)
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

        public bool DeleteOrder(uint id)
        {
            bool state = false;

            using (var connection = dbconnection.Connection)
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
