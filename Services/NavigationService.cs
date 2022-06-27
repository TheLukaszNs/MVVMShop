using System;
using MVVMShop.Stores;
using MVVMShop.ViewModel;

namespace MVVMShop.Services
{
    public class NavigationService<TViewModel> where TViewModel : BaseVM
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate() => _navigationStore.CurrentViewModel = _createViewModel();
    }
}
