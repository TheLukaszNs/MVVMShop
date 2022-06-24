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

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private List<UserRole> _roles;
        public List<UserRole> Roles
        {
            get => _roles;
            set
            {
                _roles = value;
                OnPropertyChanged(nameof(Roles));
            }
        }

        private UserRole _selectedRole;
        public UserRole SelectedRole
        {
            get => _selectedRole;
            set
            {
                _selectedRole = value;
                OnPropertyChanged(nameof(SelectedRole));
            }
        }

        public UserManagementViewModel(UsersStore usersStore, AuthStore authStore)
        {
            _usersStore = usersStore;
            _authStore = authStore;

            LoadUsers();
            Roles = Enum.GetValues(typeof(UserRole)).Cast<UserRole>().ToList();
        }

        private void LoadUsers() => Users = new ObservableCollection<User>(_usersStore.Users.Where(u => !u.Id.Equals(_authStore.AuthenticatedUser.Id)));
    }
}
