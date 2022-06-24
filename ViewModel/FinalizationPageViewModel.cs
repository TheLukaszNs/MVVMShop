using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MVVMShop.ViewModel
{
    public class FinalizationPageViewModel : BaseVM
    {
        private readonly Regex _postCodeRegex = new Regex("[0 - 9]{2}-[0-9]{3}");

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

        public FinalizationPageViewModel()
        {

        }
    }
}
