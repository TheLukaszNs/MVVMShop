using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.Model;

namespace MVVMShop.ViewModel
{
    public class CartPageViewModel : BaseVM
    {
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

        private decimal _totalPrice;
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

        public CartPageViewModel()
        {
            // init products

            TotalPrice = Products.Sum(p => p.Price);
            TotalPoints = (uint)Products.Sum(p => p.Points);
        }
    }
}
