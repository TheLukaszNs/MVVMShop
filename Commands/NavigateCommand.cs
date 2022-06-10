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
    internal class NavigateCommand : BaseCommand
    {
        private readonly NavigationService _navigationService;

        public NavigateCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}
