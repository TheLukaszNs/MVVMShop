using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.Services;
using MVVMShop.Stores;
using MVVMShop.ViewModel;

namespace MVVMShop.Commands
{
    internal class NavigateCommand<TViewModel> : BaseCommand where TViewModel : BaseVM
    {
        private readonly NavigationService<TViewModel> _navigationService;

        public NavigateCommand(NavigationService<TViewModel> navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}