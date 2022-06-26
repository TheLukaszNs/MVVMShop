using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMShop.Common.HelperTypes;
using MVVMShop.Services.OrderCreators;
using MVVMShop.Stores;
using MVVMShop.Commands;
using MVVMShop.Services;

namespace MVVMShop.ViewModel
{
    public class FinalizationPageViewModel : BaseVM
    {
        private readonly CartStore _cartStore;
        private readonly AuthStore _authStore;
        private readonly Regex _postCodeRegex = new Regex("[0-9]{2}-[0-9]{3}");
        private readonly GlobalNavigationService _globalNavigationService;

        public List<string> PaymentMethods { get; } = new() { "Przelew", "Karta", "Przy odbiorze" };
        public List<string> ShipmentMethods { get; } = new() { "Paczkomat", "Kurier", "Odbiór osobisty" };


        private string _selectedDeliveryType;

        public string SelectedDeliveryType
        {
            get => _selectedDeliveryType;
            set
            {
                _selectedDeliveryType = value;
                OnPropertyChanged(nameof(SelectedDeliveryType));
            }
        }

        private string _streetAddress;

        public string StreetAddress
        {
            get => _streetAddress;
            set
            {
                _streetAddress = value;
                OnPropertyChanged(nameof(StreetAddress));
            }
        }

        private string _postCode;

        public string PostCode
        {
            get => _postCode;
            set
            {
                _postCode = value;
                OnPropertyChanged(nameof(PostCode));
            }
        }

        private string _selectedPaymentMethod;

        public string SelectedPaymentMethod
        {
            get => _selectedPaymentMethod;
            set
            {
                _selectedPaymentMethod = value;
                OnPropertyChanged(nameof(SelectedPaymentMethod));
            }
        }

        private ICommand _finalizeOrderCommand;

        public ICommand FinalizeOrderCommand => _finalizeOrderCommand ?? (_finalizeOrderCommand = new RelayCommand(
            o => 
            {
                FinalizeOrder();
                _cartStore.ClearCart();
                _globalNavigationService.CustomerPageNavigationService.Navigate();
            },
            o => _postCodeRegex.Match(PostCode ?? "").Success
        ));

        public FinalizationPageViewModel(CartStore cartStore, AuthStore authStore, GlobalNavigationService globalNavigationService)
        {
            _cartStore = cartStore;
            _authStore = authStore;
            _globalNavigationService = globalNavigationService;
        }

        private void FinalizeOrder()
        {
            _cartStore.Finalize(new OrderMetadata
            {
                Address = StreetAddress,
                PaymentMethod = SelectedPaymentMethod,
                PostalCode = PostCode,
                ShipmentMethod = SelectedDeliveryType,
                Points = _cartStore.TotalPoints,
                Value = _cartStore.TotalPrice,
                UserId = _authStore.AuthenticatedUser.Id,
            });
        }
    }
}