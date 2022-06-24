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

        public ICommand CreateCommand => _createCommand ??= new RelayCommand(
            _ =>
            {
                _productsStore.AddProduct(new Product
                    {
                        ProductName = ProductName,
                        Availability = true,
                        Price = decimal.Parse(Price),
                        Points = uint.Parse(Points)
                    }
                );

                ClearForm();
            },
            o => decimal.TryParse(Price, out _) && int.TryParse(Points, out _)
        );

        private ICommand _setFormCommand;

        public ICommand SetFormCommand => _setFormCommand ??= new RelayCommand(
            _ =>
            {
                if (SelectedProduct == null)
                    return;

                ProductName = SelectedProduct.ProductName;
                Price = SelectedProduct.Price.ToString();
                Points = SelectedProduct.Points.ToString();
            },
            _ => true
        );

        private ICommand _editCommand;

        public ICommand EditCommand => _editCommand ??= new RelayCommand(
            _ =>
            {
                _productsStore.EditProduct(SelectedProduct.Id, new Product
                {
                    ProductName = ProductName,
                    Availability = true,
                    Price = decimal.Parse(Price),
                    Points = uint.Parse(Points)
                });

                OnPropertyChanged(nameof(Products));
                ClearForm();
            },
            o => SelectedProduct != null && decimal.TryParse(Price, out _) && int.TryParse(Points, out _)
        );

        private ICommand _deleteCommand;

        public ICommand DeleteCommand => _deleteCommand ??= new RelayCommand(
            _ =>
            {
                _productsStore.DeleteProduct(SelectedProduct.Id);

                ClearForm();
            },
            _ => SelectedProduct != null
        );

        public AdminPageViewModel(ProductsStore productsStore)
        {
            _productsStore = productsStore;
            _productsStore.ProductAdded += OnProductAdded;
            _productsStore.ProductRemoved += OnProductRemoved;
            _productsStore.ProductChanged += OnProductChanged;

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

        private void OnProductRemoved(Product product)
        {
            _products.Remove(product);
        }

        private void OnProductChanged() => LoadProducts();

        private void LoadProducts()
        {
            Products = new ObservableCollection<Product>(_productsStore.Products);
        }

        public override void Dispose()
        {
            _productsStore.ProductAdded -= OnProductAdded;
            _productsStore.ProductRemoved -= OnProductRemoved;
            _productsStore.ProductChanged -= OnProductChanged;
            base.Dispose();
        }
    }
}