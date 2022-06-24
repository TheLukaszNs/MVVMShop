using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.Stores;
using MVVMShop.Model;
using MVVMShop.DTOs;

namespace MVVMShop.ViewModel
{
    public class UserManagementViewModel : BaseVM
    {
        private readonly UsersStore _usersStore;
        private readonly AuthStore _authStore;

        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        private User _selectedUser;
        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        public UserManagementViewModel(UsersStore usersStore, AuthStore authStore)
        {
            _usersStore = usersStore;
            _authStore = authStore;

            LoadUsers();
        }

        private void LoadUsers() => Users = new ObservableCollection<User>(_usersStore.Users.Where(u => !u.Id.Equals(_authStore.AuthenticatedUser.Id)));
    }
}
