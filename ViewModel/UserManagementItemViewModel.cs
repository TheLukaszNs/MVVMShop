using System.Globalization;
using MVVMShop.DTOs;
using MVVMShop.Model;
using MVVMShop.Stores;

namespace MVVMShop.ViewModel
{
    public class UserManagementItemViewModel : BaseVM
    {
        private User _user;
        private readonly UsersStore _usersStore;

        public string Email => _user.Email;
        public string Name => CultureInfo.CurrentCulture.TextInfo.ToTitleCase($"{_user.FirstName} {_user.LastName}");

        public UserRole Role
        {
            get => _user.Role;
            set
            {
                ChangeRole(value);
                OnPropertyChanged(nameof(Role));
            }
        }

        public UserManagementItemViewModel(User user, UsersStore usersStore)
        {
            _user = user;
            _usersStore = usersStore;
        }

        public void ChangeRole(UserRole role)
        {
            _user.Role = role;
            _usersStore.EditUser(_user.Id, _user);
        }
    }
}