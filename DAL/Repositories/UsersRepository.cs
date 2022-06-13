using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MVVMShop.DAL.Repositories
{
    using Entities;

    internal static class UsersRepository
    {
        #region Queries

        private const string SELECT_ALL = "SELECT * FROM users";
        private const string INSERT = "INSERT users VALUE";
        private const string DELETE = "DELETE FROM users WHERE id=";

        #endregion

        #region Methods

        public static List<Users> GetUsers()
        {
            List<Users> users = new List<Users>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(SELECT_ALL, connection);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                    users.Add(new Users(reader));

                connection.Close();
            }

            return users;
        }

        public static bool AddUser(Users user)
        {
            bool state = false;

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{INSERT} {user.Insert()}", connection);

                connection.Open();

                state = true;
                user.Id = (uint)command.LastInsertedId;

                connection.Close();
            }

            return state;
        }

        // Can modify Role only
        public static bool EditUser(Users user, uint id)
        {
            bool state = false;

            using (var connection = DBConnection.Instance.Connection)
            {
                string MODIFY = $"UPDATE users " +
                    $"SET " +
                    $"user_role={user.Role} " +
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

        public static bool DeleteUser(uint id)
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
