using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.Stores;

namespace MVVMShop.ViewModel
{
    public class HistoryPageViewModel : BaseVM
    {
        private readonly OrdersStore _ordersStore;
        private readonly AuthStore _authStore;

        private ObservableCollection<HistoryPageItemViewModel> _orders;
        public ObservableCollection<HistoryPageItemViewModel> Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        public HistoryPageViewModel(OrdersStore ordersStore, AuthStore authStore)
        {
            _ordersStore = ordersStore;
            _authStore = authStore;

            LoadOrders();
        }

        private void LoadOrders() => Orders = new ObservableCollection<HistoryPageItemViewModel>(_ordersStore.Orders
            .Where(o => o.Customer.Id.Equals(_authStore.AuthenticatedUser.Id))
            .Select(o => new HistoryPageItemViewModel(o, _ordersStore)));
    }
}
