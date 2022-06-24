using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.Model;
using MVVMShop.Services.UserProvider;
using MVVMShop.DTOs;

namespace MVVMShop.Stores
{
    public class UsersStore
    {
        private readonly IUserProvider _userProvider;

        public List<User> Users { get; set; } = new();
        public List<UserRole> Roles { get; set; } = new();

        public UsersStore(IUserProvider userProvider)
        {
            _userProvider = userProvider;

            InitUsers();
        }

        private void InitUsers()
        {
            Users.Clear();

            var users = _userProvider.GetAllUsers();

            if (users != null)
                Users.AddRange(users);
        }
    }
}
