using System.Collections.ObjectModel;
using System.Linq;
using MVVMShop.Stores;

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
            _ordersStore.OrdersLoaded += LoadOrders;

            LoadOrders();
        }

        private void LoadOrders() => Orders = new ObservableCollection<AssisstantListItemViewModel>(_ordersStore.Orders.Select(o => new AssisstantListItemViewModel(o, _ordersStore)));

        public override void Dispose()
        {
            _ordersStore.OrdersLoaded -= LoadOrders;

            base.Dispose();
        }
    }
}
