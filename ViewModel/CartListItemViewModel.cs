using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMShop.Model;
using MVVMShop.Stores;

namespace MVVMShop.ViewModel
{
    public class CartListItemViewModel : BaseVM
    {
        private readonly CartStore _cartStore;

        private Product _product;
        private uint _count;
        public uint Count
        {
            get => _count;
            set 
            {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        public string ProductName => _product.ProductName;
        public decimal Price => _product.Price;
        public uint Points => _product.Points * _count;

        private ICommand _deleteCommand;
        public ICommand DeleteCommand => _deleteCommand ?? (_deleteCommand = new RelayCommand(
            _ =>
            {
                _cartStore.RemoveFromCart(_product);
                Count--;
            },
            _ => true
        ));

        public CartListItemViewModel(CartStore cartStore, Product product, uint count)
        {
            _cartStore = cartStore;
            _product = product;
            _count = count;
        }
    }
}
