using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MVVMShop.Commands;
using MVVMShop.Common.HelperTypes;
using MVVMShop.DAL;
using MVVMShop.DAL.Entities;
using MVVMShop.Model;
using MVVMShop.Services;
using MVVMShop.Services.Auth;
using System.Text.RegularExpressions;

namespace MVVMShop.ViewModel
{
    public class RegisterPageViewModel : BaseVM
    {
        private readonly NavigationService<LoginPageViewModel> _navigationService;
        private readonly IAuthService _authService;

        private Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

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

        public ICommand GoToLoginPageCommand { get; }

        private ICommand _registerCommand;

        public ICommand RegisterCommand => _registerCommand ?? (_registerCommand = new RelayCommand(
            o => Register(),
            o => regex.Match(Email ?? "").Success 
        ));

        public RegisterPageViewModel(NavigationService<LoginPageViewModel> navigationService, IAuthService authService)
        {
            _navigationService = navigationService;
            _authService = authService;
            GoToLoginPageCommand = new NavigateCommand<LoginPageViewModel>(navigationService);
        }

        private void Register()
        {
            User user = _authService.Register(new UserRegisterData
            {
                Email = Email,
                LastName = LastName,
                FirstName = FirstName,
                Password = Password,
                Role = UserRole.Klient
            });

            if (user != null)
                _navigationService.Navigate();
        }
    }
}