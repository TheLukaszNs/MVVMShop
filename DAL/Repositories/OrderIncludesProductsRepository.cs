﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MVVMShop.DAL.Repositories
{
    using Entities;

    internal static class OrderIncludesProductsRepository
    {
        #region Queries

        private const string SELECT = "SELECT * FROM order_includes_products WHERE id_o=";
        private const string INSERT = "INSERT order_includes_products VALUE";
        private const string DELETE = "DELETE FROM order_includes_products WHERE id=";

        #endregion

        #region Methods

        public static List<OrderIncludesProducts> Get(uint idO)
        {
            List<OrderIncludesProducts> data = new List<OrderIncludesProducts>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{SELECT}{idO}", connection);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                    data.Add(new OrderIncludesProducts(reader));

                connection.Close();
            }

            return data;
        }

        public static bool Add(OrderIncludesProducts oip)
        {
            bool state = false;

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{INSERT} {oip.Insert()}", connection);

                connection.Open();

                state = true;
                oip.Id = (uint)command.LastInsertedId;

                connection.Close();
            }

            return state;
        }

        public static bool Delete(uint id)
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
