using System.Collections.ObjectModel;
using System.Linq;
using MVVMShop.Stores;

namespace MVVMShop.ViewModel
{
  public class UserManagementViewModel : BaseVM
  {
    private readonly UsersStore _usersStore;
    private readonly AuthStore _authStore;

    private ObservableCollection<UserManagementItemViewModel> _users;

    public ObservableCollection<UserManagementItemViewModel> Users
    {
      get => _users;
      set
      {
        _users = value;
        OnPropertyChanged(nameof(Users));
      }
    }

    public UserManagementViewModel(UsersStore usersStore, AuthStore authStore)
    {
      _usersStore = usersStore;
      _authStore = authStore;

      LoadUsers();
    }

    private void LoadUsers() => Users = new ObservableCollection<UserManagementItemViewModel>(_usersStore.Users
        .Where(u => !u.Id.Equals(_authStore.AuthenticatedUser.Id))
        .Select(u => new UserManagementItemViewModel(u, _usersStore)));
  }
}