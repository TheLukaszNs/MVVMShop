using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MVVMShop.Common.Hashers;
using MVVMShop.Common.HelperTypes;
using MVVMShop.DAL;
using MVVMShop.DAL.Entities;
using MVVMShop.DAL.Repositories;
using MVVMShop.Exceptions;
using MVVMShop.Model;
using MVVMShop.Services.Auth;
using MVVMShop.Stores;
using MySql.Data.MySqlClient;

namespace MVVMShop.Services
{
    internal class DbAuthService : IAuthService
    {
        private readonly BaseRepository<Users> _usersRepository;
        private readonly IHasher _passwordHasher;

        public DbAuthService(BaseRepository<Users> usersRepository, IHasher passwordHasher)
        {
            _usersRepository = usersRepository;
            _passwordHasher = passwordHasher;
        }

        public User LogIn(string email, string password)
        {
            if (email == null || password == null)
                return null;

            Users userDb = _usersRepository.Get(GetDataFromDatabase)
                .FirstOrDefault(u => u.UserEmail == email);

            if (userDb is null || !_passwordHasher.Equals(userDb.UserPassword, password))
                throw new AuthFailedException("Podano błędny email lub hasło!");

            return new User(userDb);
        }

        public bool Register(UserRegisterData userData)
        {
            if (userData == null)
                return false;

            Users userDb = _usersRepository.Get(GetDataFromDatabase)
                .FirstOrDefault(u => u.UserEmail == userData.Email);

            if (!(userDb is null))
                throw new AuthFailedException("Użytkownik o podanym adresie już istnieje!");

            userDb = new Users(userData.Email, _passwordHasher.Hash(userData.Password), userData.FirstName,
                userData.LastName, userData.Role);

            return _usersRepository.Add(userDb, new Dictionary<string, string>
            {
                ["@Email"] = userDb.UserEmail,
                ["@Password"] = userDb.UserPassword,
                ["@FirstName"] = userDb.FirstName,
                ["@LastName"] = userDb.LastName,
                ["@Role"] = UserRole.Klient.ToString(),
            });
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }

        private Users GetDataFromDatabase(MySqlDataReader reader)
        {
            return new Users
            {
                Id = uint.Parse(reader["id"]
                    .ToString()),
                UserEmail = reader["user_email"]
                    .ToString(),
                UserPassword = reader["user_password"]
                    .ToString(),
                FirstName = reader["first_name"]
                    .ToString(),
                LastName = reader["last_name"]
                    .ToString(),
                Role = (UserRole)Enum.Parse(typeof(UserRole), reader["user_role"]
                    .ToString())
            };
        }
    }
}