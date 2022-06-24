using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.Model;
using MVVMShop.Stores;

namespace MVVMShop.ViewModel
{
    public class CustomerPageViewModel : BaseVM
    {
        private readonly ProductsStore _productsStore;

        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
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

        public CustomerPageViewModel(ProductsStore productsStore)
        {
            _productsStore = productsStore;

            LoadProducts();
        }

        private void LoadProducts() => Products = new ObservableCollection<Product>(_productsStore.Products);
    }
}
