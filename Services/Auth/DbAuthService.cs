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

        public DbAuthService(AuthStore authStore)
        {
            _authStore = authStore;
        }

        public bool LogIn(string email, string password)
        {
            if (email == null || password == null) return false;


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