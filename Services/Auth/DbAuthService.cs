using System;
using System.Linq;
using MVVMShop.Common.Hashers;
using MVVMShop.Common.HelperTypes;
using MVVMShop.DB.DbContexts;
using MVVMShop.DTOs;
using MVVMShop.Exceptions;
using MVVMShop.Model;
using MVVMShop.Services.Auth;

namespace MVVMShop.Services
{
    public class DbAuthService : IAuthService
    {
        private readonly MVVMShopContextFactory _dbContextFactory;
        private readonly IHasher _passwordHasher;

        public DbAuthService(MVVMShopContextFactory dbContextFactory, IHasher passwordHasher)
        {
            _dbContextFactory = dbContextFactory;
            _passwordHasher = passwordHasher;
        }

        public User LogIn(string email, string password)
        {
            if (email == null || password == null)
                return null;

            using var context = _dbContextFactory.CreateDbContext();
            var user = (from u in context.Users
                where u.Email == email
                select u).FirstOrDefault();

            if (user is null || !_passwordHasher.Equals(user.Password, password))
                throw new AuthFailedException("Podano błędny email lub hasło!");

            return ToUser(user);
        }

        public void Register(UserRegisterData userData)
        {
            if (userData == null)
                return;

            using var context = _dbContextFactory.CreateDbContext();
            var user = (from u in context.Users
                where u.Email == userData.Email
                select u).FirstOrDefault();

            if (user is not null)
                throw new AuthFailedException("Użytkownik o podanym adresie już istnieje!");

            user = ToUserDto(userData);

            context.Users.Add(user);
            context.SaveChanges();
        }

        public void LogOut() => throw new NotImplementedException();

        private UserDTO ToUserDto(UserRegisterData user) => new()
        {
            Email = user.Email,
            Password = _passwordHasher.Hash(user.Password),
            FirstName = user.FirstName,
            LastName = user.LastName,
            Role = UserRole.Klient,
        };

        private User ToUser(UserDTO user) =>
            new(user.Id, user.Email, user.FirstName, user.LastName, user.Role, user.Points);
    }
}