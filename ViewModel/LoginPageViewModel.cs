using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MVVMShop.Commands;
using MVVMShop.Services;
using MVVMShop.Services.Auth;

namespace MVVMShop.ViewModel
{
    public class LoginPageViewModel : BaseVM
    {
        private string _login = "admin@mvvmshop.com";

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        private string _password = "Test";

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private readonly IAuthService _authService;

        public ICommand GoToRegisterPageCommand { get; }

        private ICommand _loginCommand;

        public ICommand LoginCommand =>
            _loginCommand ?? (_loginCommand = new RelayCommand(
                    o => LogIn()
                )
            );

        public LoginPageViewModel(NavigationService<RegisterPageViewModel> navigationService, IAuthService authService)
        {
            GoToRegisterPageCommand = new NavigateCommand<RegisterPageViewModel>(navigationService);
            _authService = authService;
        }

        private void LogIn()
        {
            _authService.LogIn(Login, Password);
        }
    }
}