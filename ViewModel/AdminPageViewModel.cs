using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMShop.Model;
using MVVMShop.Services.OrderCreators;
using MVVMShop.Services.ProductCreators;
using MVVMShop.Stores;

namespace MVVMShop.ViewModel
{
    public class AdminPageViewModel : BaseVM
    {
        private readonly ProductsStore _productsStore;

        private ObservableCollection<Product> _products;

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

        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        private string _productName;

        public string ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        private string _price;

        public string Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        private string _points;

        public string Points
        {
            get => _points;
            set
            {
                _points = value;
                OnPropertyChanged(nameof(Points));
            }
        }

        private ICommand _createCommand;

        public ICommand CreateCommand => _createCommand ?? (_createCommand = new RelayCommand(
            o =>
            {
                _productsStore.AddProduct(new Product
                    {
                        ProductName = ProductName,
                        Availability = true,
                        Price = decimal.Parse(Price)
                    }
                );

                ClearForm();
            },
            o => decimal.TryParse(Price, out _) && int.TryParse(Points, out _)
        ));

        private ICommand _setFormCommand;
        public ICommand SetFormCommand => _setFormCommand ?? (_setFormCommand = new RelayCommand(
            o =>
            {
                ProductName = SelectedProduct.ProductName;
                Price = SelectedProduct.Price.ToString();
            },
            o => true
        ));

        private ICommand _editCommand;
        private ICommand EditCommand => _editCommand ?? (_editCommand = new RelayCommand(
            o =>
            {
                _productsStore.EditProduct(SelectedProduct.Id);

                ClearForm();
            },
            o => SelectedProduct != null
        ));

        private ICommand _deleteCommand;
        public ICommand DeleteCommand => _deleteCommand ?? (_deleteCommand = new RelayCommand(
            o =>
            {


                ClearForm();
            },
            o => SelectedProduct != null
        ));

        public AdminPageViewModel(ProductsStore productsStore)
        {
            _productsStore = productsStore;
            _productsStore.ProductAdded += OnProductAdded;
            LoadProducts();
        }

        private void ClearForm()
        {
            ProductName = "";
            Price = "";
            Points = "";
        }

        private void OnProductAdded(Product product)
        {
            _products.Add(product);
        }

        private void LoadProducts()
        {
            Products = new ObservableCollection<Product>(_productsStore.Products);
        }

        public override void Dispose()
        {
            _productsStore.ProductAdded -= OnProductAdded;
            base.Dispose();
        }
    }
}