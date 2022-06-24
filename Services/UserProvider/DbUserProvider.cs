using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.Model;
using MVVMShop.DB.DbContexts;

namespace MVVMShop.Services.UserProvider
{
    public class DbUserProvider : IUserProvider
    {
        private readonly MVVMShopContextFactory _dbContextFactory;

        public DbUserProvider(MVVMShopContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public IEnumerable<User> GetAllUsers()
        {
            using var context = _dbContextFactory.CreateDbContext();

            var users = context.Users.ToList();

            return users.Select(u => new User
            {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Role = u.Role,
                Points = u.Points
            });
        }
    }
}
