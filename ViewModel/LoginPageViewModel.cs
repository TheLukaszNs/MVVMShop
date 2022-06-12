using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMShop.Commands;
using MVVMShop.Services;

namespace MVVMShop.ViewModel
{
    public class LoginPageViewModel : BaseVM
    {
        public ICommand GoToRegisterPageCommand { get; }

        public LoginPageViewModel(NavigationService<RegisterPageViewModel> navigationService)
        {
            GoToRegisterPageCommand = new NavigateCommand<RegisterPageViewModel>(navigationService);
        }
    }
}