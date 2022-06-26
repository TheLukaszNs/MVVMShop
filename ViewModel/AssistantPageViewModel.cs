using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.Stores;
using MVVMShop.Model;

namespace MVVMShop.ViewModel
{
    public class AssistantPageViewModel : BaseVM
    {
        private readonly OrdersStore _ordersStore;

        private ObservableCollection<AssisstantListItemViewModel> _orders;
        public ObservableCollection<AssisstantListItemViewModel> Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        public AssistantPageViewModel(OrdersStore ordersStore)
        {
            _ordersStore = ordersStore;

            LoadOrders();
        }

        private void LoadOrders() => Orders = new ObservableCollection<AssisstantListItemViewModel>(_ordersStore.Orders.Select(o => new AssisstantListItemViewModel(o, _ordersStore)));
    }
}
