using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMShop.Model;
using MVVMShop.Stores;

namespace MVVMShop.ViewModel
{
    public class CustomerPageViewModel : BaseVM
    {
        private readonly ProductsStore _productsStore;
        private readonly CartStore _cartStore;

        private ObservableCollection<ProductsListItemViewModel> _products;
        public ObservableCollection<ProductsListItemViewModel> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        public CustomerPageViewModel(ProductsStore productsStore, CartStore cartStore)
        {
            _productsStore = productsStore;
            _cartStore = cartStore;

            LoadProducts();
        }

        private void LoadProducts() => Products = new ObservableCollection<ProductsListItemViewModel>(_productsStore.Products.Select(p => new ProductsListItemViewModel(p, _cartStore)));
    }
}
