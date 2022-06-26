using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMShop.Commands;
using MVVMShop.Model;
using MVVMShop.Services;
using MVVMShop.Stores;

namespace MVVMShop.ViewModel
{
    public class CartPageViewModel : BaseVM
    {
        private readonly CartStore _cartStore;

        private ObservableCollection<CartListItemViewModel> _products;

        public ObservableCollection<CartListItemViewModel> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        private decimal _totalPrice = 0;

        public decimal TotalPrice
        {
            get => _totalPrice;
            set
            {
                _totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        private uint _totalPoints;

        public uint TotalPoints
        {
            get => _totalPoints;
            set
            {
                _totalPoints = value;
                OnPropertyChanged(nameof(TotalPoints));
            }
        }

        public ICommand GoToFinalizeCommand { get; }

        public CartPageViewModel(CartStore cartStore, GlobalNavigationService navigationService)
        {
            _cartStore = cartStore;
            _cartStore.CartUpdated += ReloadCart;
            GoToFinalizeCommand =
                new NavigateCommand<FinalizationPageViewModel>(navigationService.FinalizationPageNavigationService);

            ReloadCart();
        }

        private void ReloadCart()
        {
            Products?.Clear();
            Products = new ObservableCollection<CartListItemViewModel>(
                _cartStore.Products.Select(p => new CartListItemViewModel(_cartStore, p.Key, p.Value)));

            TotalPrice = 0;
            TotalPoints = 0;

            foreach (var product in Products)
            {
                TotalPrice += product.Price * product.Count;
                TotalPoints += product.Points * product.Count;
            }
        }

        public override void Dispose()
        {
            _cartStore.CartUpdated -= ReloadCart;
            base.Dispose();
        }
    }
}