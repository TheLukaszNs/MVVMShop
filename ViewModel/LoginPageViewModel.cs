using System;
using System.Windows.Input;
using MVVMShop.Commands;
using MVVMShop.DTOs;
using MVVMShop.Exceptions;
using MVVMShop.Services;
using MVVMShop.Services.Auth;
using MVVMShop.Stores;
using System.Text.RegularExpressions;

namespace MVVMShop.ViewModel
{
    public class LoginPageViewModel : BaseVM
    {
        //private readonly UserModel _userModel;

        private Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        private string _login;

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        private string _password;

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private readonly NavigationService<CustomerPageViewModel> _customerNavigation;
        private readonly NavigationService<AssistantPageViewModel> _assistantNavigation;
        private readonly NavigationService<AdminPageViewModel> _adminNavigation;
        private readonly IAuthService _authService;
        private readonly AuthStore _authStore;

        public ICommand GoToRegisterPageCommand { get; }

        private ICommand _loginCommand;

        public ICommand LoginCommand =>
            _loginCommand ?? (_loginCommand = new RelayCommand(
                    o => LogIn(),
                    o => regex.Match(Login ?? "")
                        .Success
                )
            );

        public LoginPageViewModel(NavigationService<RegisterPageViewModel> registerNavigationService,
            NavigationService<CustomerPageViewModel> customerNavigation,
            NavigationService<AssistantPageViewModel> assistantNavigation,
            NavigationService<AdminPageViewModel> adminNavigation, IAuthService authService,
            AuthStore authStore)
        {
            GoToRegisterPageCommand = new NavigateCommand<RegisterPageViewModel>(registerNavigationService);
            _customerNavigation = customerNavigation;
            _assistantNavigation = assistantNavigation;
            _adminNavigation = adminNavigation;
            _authService = authService;
            _authStore = authStore;
        }

        private void LogIn()
        {
            try
            {
                var user = _authService.LogIn(Login, Password);

                _authStore.AuthenticatedUser = user;

                switch (user.Role)
                {
                    case UserRole.Klient:
                        _customerNavigation.Navigate();
                        break;
                    case UserRole.Pracownik:
                        _assistantNavigation.Navigate();
                        break;
                    case UserRole.Admin:
                        _adminNavigation.Navigate();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (AuthFailedException)
            {
                // Handle the auth failure
            }
        }
    }
}