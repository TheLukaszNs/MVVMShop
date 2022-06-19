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
    public class DbAuthService : IAuthService
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

            Users userDb = _usersRepository.Get(Users.FromDatabaseReader)
                .FirstOrDefault(u => u.UserEmail == email);

            if (userDb is null || !_passwordHasher.Equals(userDb.UserPassword, password))
                throw new AuthFailedException("Podano błędny email lub hasło!");

            return new User(userDb);
        }

        public User Register(UserRegisterData userData)
        {
            if (userData == null)
                return null;

            Users userDb = _usersRepository.Get(Users.FromDatabaseReader)
                .FirstOrDefault(u => u.UserEmail == userData.Email);

            if (!(userDb is null))
                throw new AuthFailedException("Użytkownik o podanym adresie już istnieje!");

            userDb = new Users(userData.Email, _passwordHasher.Hash(userData.Password), userData.FirstName,
                userData.LastName, userData.Role);

            userDb = _usersRepository.Add(ref userDb, new Dictionary<string, string>
            {
                ["@Email"] = userDb.UserEmail,
                ["@Password"] = userDb.UserPassword,
                ["@FirstName"] = userDb.FirstName,
                ["@LastName"] = userDb.LastName,
                ["@Role"] = UserRole.Klient.ToString(),
            });

            return new User(userDb);
        }

        public void LogOut()
        {
            throw new NotImplementedException();
        }
    }
}