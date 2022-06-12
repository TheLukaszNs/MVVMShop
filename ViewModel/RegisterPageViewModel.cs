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
    public class RegisterPageViewModel : BaseVM
    {
        public ICommand GoToLoginPageCommand { get; }

        public RegisterPageViewModel(NavigationService<LoginPageViewModel> navigationService)
        {
            GoToLoginPageCommand = new NavigateCommand<LoginPageViewModel>(navigationService);
        }
    }
}
