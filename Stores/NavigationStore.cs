using System;
using MVVMShop.ViewModel;

namespace MVVMShop.Stores
{
    public class NavigationStore
    {
        private BaseVM _currentViewModel;

        public BaseVM CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public event Action CurrentViewModelChanged;

        private void OnCurrentViewModelChanged() => CurrentViewModelChanged?.Invoke();
    }
}