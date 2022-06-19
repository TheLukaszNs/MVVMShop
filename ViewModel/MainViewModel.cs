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

        public BaseVM CurrentViewModel => _navigationStore.CurrentViewModel;
        public User CurrentUser => _authStore.AuthenticatedUser;
        public bool IsAuthenticated => _authStore.IsAuthenticated;

        private ICommand _logoutCommand;

        public ICommand LogoutCommand => _logoutCommand ?? (_logoutCommand = new RelayCommand(
            o => _authStore.AuthenticatedUser = null
        ));

        public MainViewModel(NavigationStore navigationStore, AuthStore authStore,
            NavigationService<StartPageViewModel> navigationService)
        {
            _navigationStore = navigationStore;
            _authStore = authStore;
            _navigationService = navigationService;

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