using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MVVMShop.DAL;
using MVVMShop.Services.Auth;
using MVVMShop.Stores;
using MySql.Data.MySqlClient;

namespace MVVMShop.Services
{
    internal class DbAuthService : IAuthService
    {
        private readonly AuthStore _authStore;
        private readonly DbConnection _dbConnection;

        public DbAuthService(AuthStore authStore, DbConnection dbConnection)
        {
            _authStore = authStore;
            _dbConnection = dbConnection;
        }

        public bool LogIn(string email, string password)
        {
            if (email == null || password == null) return false;

            using (var connection = _dbConnection.Connection)
            {
                connection.Open();

                var command = new MySqlCommand($"SELECT * FROM users WHERE user_email=@Email", connection);
                command.Parameters.AddWithValue("@Email", email);
                MySqlDataReader reader = command.ExecuteReader();

                connection.Close();
            }

            return false;
        }

        public bool Register()
        {
            throw new NotImplementedException();
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }
    }
}