using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMShop.Commands;
using MVVMShop.Services;
using MVVMShop.Stores;
using MVVMShop.ViewModel;

namespace MVVMShop.ViewModel
{
    public class StartPageViewModel : BaseVM
    {
        public ICommand GoToRegisterCommand { get; }
        public ICommand GoToLoginCommand { get; }

        public StartPageViewModel(GlobalNavigationService navigationService)
        {
            GoToRegisterCommand =
                new NavigateCommand<RegisterPageViewModel>(navigationService.RegisterPageNavigationService);
            GoToLoginCommand = new NavigateCommand<LoginPageViewModel>(navigationService.LoginPageNavigationService);
        }
    }
}