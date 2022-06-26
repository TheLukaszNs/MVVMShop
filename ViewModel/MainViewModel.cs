using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using MVVMShop.DTOs;
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
        private readonly GlobalNavigationService _navigationService;

        public BaseVM CurrentViewModel => _navigationStore.CurrentViewModel;
        public User CurrentUser => _authStore.AuthenticatedUser;

        public bool IsAuthenticated => _authStore.IsAuthenticated;

        // TODO: 🤨 sussy bug here lol
        // FIXED: GOT IT 😎
        public bool CanExecuteSecondaryAction { get; set; }

        public PackIconKind NavBarActionIconKind => CurrentUser?.Role switch
        {
            UserRole.Admin => PackIconKind.AccountGroupOutline,
            UserRole.Pracownik => PackIconKind.PackageVariant,
            UserRole.Klient => PackIconKind.ShoppingCartOutline,
            _ => PackIconKind.Abacus
        };

        private ICommand _navBarActionCommand;

        public ICommand NavBarActionCommand => _navBarActionCommand ??= new RelayCommand(_ =>
        {
            switch (CurrentUser.Role)
            {
                case UserRole.Admin:
                    _navigationService.UserManagementNavigationService.Navigate();
                    break;
                case UserRole.Pracownik:
                    break;
                case UserRole.Klient:
                    _navigationService.CartPageNavigationService.Navigate();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        });

        private ICommand _navBarHomeCommand;

        public ICommand NavBarHomeCommand => _navBarHomeCommand ??= new RelayCommand(_ =>
        {
            switch (CurrentUser.Role)
            {
                case UserRole.Admin:
                    _navigationService.AdminPageNavigationService.Navigate();
                    break;
                case UserRole.Pracownik:
                    _navigationService.AssistantPageNavigationService.Navigate();
                    break;
                case UserRole.Klient:
                    _navigationService.CustomerPageNavigationService.Navigate();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        });

        private ICommand _navBarSecondaryCommand;

        public ICommand NavBarSecondaryCommand => _navBarSecondaryCommand ??=
            new RelayCommand(_ => _navigationService.HistoryPageNavigationService.Navigate());

        private ICommand _logoutCommand;

        public ICommand LogoutCommand => _logoutCommand ??= new RelayCommand(
            _ => _authStore.AuthenticatedUser = null
        );

        public MainViewModel(NavigationStore navigationStore, AuthStore authStore,
            GlobalNavigationService navigationService)
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
                _navigationService.StartPageNavigationService.Navigate();

            OnPropertyChanged(nameof(IsAuthenticated));
            OnPropertyChanged(nameof(CurrentUser));
            OnPropertyChanged(nameof(NavBarActionIconKind));
            OnPropertyChanged(nameof(NavBarActionCommand));
            OnPropertyChanged(nameof(NavBarHomeCommand));

            if (user != null)
                CanExecuteSecondaryAction = user.Role == UserRole.Klient;
            OnPropertyChanged(nameof(CanExecuteSecondaryAction));
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