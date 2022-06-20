using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMShop.Model;
using MVVMShop.Services;
using MVVMShop.Services.Auth;
using MVVMShop.Stores;
using MVVMShop.ViewModel;

namespace MVVMShop.ViewModel
{
    public class MainViewModel : BaseVM
    {
        private readonly NavigationStore _navigationStore;
        private readonly AuthStore _authStore;
        private readonly NavigationService<StartPageViewModel> _navigationService;
        private readonly NavigationService<UserManagementViewModel> _userManagementNavigation;
        private readonly NavigationService<CartPageViewModel> _cartPageNavigation;

        public BaseVM CurrentViewModel => _navigationStore.CurrentViewModel;
        public User CurrentUser => _authStore.AuthenticatedUser;
        public bool IsAuthenticated => _authStore.IsAuthenticated;

        private ICommand _userManagementCommand;
        public ICommand UserManagementCommand => _userManagementCommand ?? (_userManagementCommand = new RelayCommand(
            o => _userManagementNavigation.Navigate()
        ));

        private ICommand _cartPageCommand;
        public ICommand CartPageCommand => _cartPageCommand ?? (_cartPageCommand = new RelayCommand(
            o => _cartPageNavigation.Navigate()
        ));

        private ICommand _logoutCommand;

        public ICommand LogoutCommand => _logoutCommand ?? (_logoutCommand = new RelayCommand(
            o => _authStore.AuthenticatedUser = null
        ));

        public MainViewModel(NavigationStore navigationStore, AuthStore authStore,
            NavigationService<StartPageViewModel> navigationService, NavigationService<UserManagementViewModel> userManagementNavigation, NavigationService<CartPageViewModel> cartPageNavigation)
        {
            _navigationStore = navigationStore;
            _authStore = authStore;
            _navigationService = navigationService;
            _userManagementNavigation = userManagementNavigation;
            _cartPageNavigation = cartPageNavigation;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _authStore.AuthStateChanged += OnAuthStateChanged;
        }

        private void OnAuthStateChanged(User user)
        {
            if (user == null)
                _navigationService.Navigate();

            OnPropertyChanged(nameof(IsAuthenticated));
            OnPropertyChanged(nameof(CurrentUser));
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public override void Dispose()
        {
            _navigationStore.CurrentViewModelChanged -= OnCurrentViewModelChanged;
            _authStore.AuthStateChanged -= OnAuthStateChanged;

            base.Dispose();
        }
    }
}