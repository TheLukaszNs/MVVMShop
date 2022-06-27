using System.Windows.Input;
using MVVMShop.Commands;
using MVVMShop.Services;

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