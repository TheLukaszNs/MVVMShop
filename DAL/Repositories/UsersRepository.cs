using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MVVMShop.DAL.Repositories
{
    using Entities;

    internal sealed class UsersRepository
    {
        #region Queries

        private const string SELECT_ALL = "SELECT * FROM users";
        private const string INSERT = "INSERT users VALUE (0, @Email, @Password, @FirstName, @LastName, @Role)";
        private const string DELETE = "DELETE FROM users WHERE id=";

        #endregion

        #region Properties

        private readonly DbConnection dbconnection;

        #endregion

        #region Constuctors

        public UsersRepository(DbConnection dbconnection) => this.dbconnection = dbconnection;

        #endregion

        #region Methods

        public List<Users> GetUsers()
        {
            List<Users> users = new List<Users>();

            using (var connection = dbconnection.Connection)
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

        public bool AddUser(Users user)
        {
            bool state = false;

            using (var connection = dbconnection.Connection)
            {
                MySqlCommand command = new MySqlCommand(INSERT, connection);
                command.Parameters.AddWithValue("@Email", user.UserEmail);
                command.Parameters.AddWithValue("@Password", user.UserPassword);
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@Role", user.Role.ToString());

                connection.Open();

                var id = command.ExecuteNonQuery();
                state = true;
                user.Id = (uint)command.LastInsertedId;

                connection.Close();
            }

            return state;
        }

        // Can modify Role only
        public bool EditUser(Users user, uint id)
        {
            bool state = false;

            using (var connection = dbconnection.Connection)
            {
                string MODIFY = $"UPDATE users " +
                                $"SET " +
                                $"user_email={user.UserEmail} " +
                                $"user_password={user.UserPassword} " +
                                $"firstname={user.FirstName} " +
                                $"lastname={user.LastName} " +
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

        public bool DeleteUser(uint id)
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