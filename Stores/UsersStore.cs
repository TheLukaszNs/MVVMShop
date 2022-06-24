using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.Model;
using MVVMShop.Services.UserProvider;
using MVVMShop.DTOs;
using MVVMShop.Services.UserEditor;

namespace MVVMShop.Stores
{
    public class UsersStore
    {
        private readonly IUserProvider _userProvider;
        private readonly IUserEditor _userEditor;

        public List<User> Users { get; set; } = new();
        public List<UserRole> Roles { get; set; } = new();

        public UsersStore(IUserProvider userProvider, IUserEditor userEditor)
        {
            _userProvider = userProvider;
            _userEditor = userEditor;

            InitUsers();
        }

        public event Action UserChanged;

        public void EditUser(Guid id, User editedUser)
        {
            var newUser = _userEditor.EditUser(id, editedUser);
            if (newUser is null)
                return;

            var index = Users.FindIndex(x => x.Id == id);
            Users[index] = editedUser;
            OnUserChanged();
        }

        private void InitUsers()
        {
            Users.Clear();

            var users = _userProvider.GetAllUsers();

            if (users != null)
                Users.AddRange(users);
        }

        private void OnUserChanged() => UserChanged?.Invoke();
    }
}