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
    public class ProductsListItemViewModel : BaseVM
    {
        private readonly Product _product;
        private readonly CartStore _cartStore;

        public string ProductName => _product.ProductName;
        public decimal Price => _product.Price;

        private ICommand _addToCartCommand;
        public ICommand AddToCartCommand => _addToCartCommand ?? (_addToCartCommand = new RelayCommand(
            _ => _cartStore.AddToCart(_product),
            _ => true
        ));

        public ProductsListItemViewModel(Product product, CartStore cartStore)
        {
            _product = product;
            _cartStore = cartStore;
        }
    }
}
