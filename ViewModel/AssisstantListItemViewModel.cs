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
    public class AssisstantListItemViewModel : BaseVM
    {
        private readonly Order _order;
        private readonly OrdersStore _orderStore;

        public Guid Id => _order.Id;
        public string Status => _order.Status.ToString();

        private ICommand _acceptOrder;
        public ICommand AcceptOrder => _acceptOrder ?? (_acceptOrder = new RelayCommand(
            _ =>
            {
                _order.Status = DTOs.OrderStatus.Zrealizowane;
                _orderStore.EditOrder(Id, _order);
                OnPropertyChanged(nameof(Status));
            }, 
            _ => true
        ));

        private ICommand _cancelOrder;
        public ICommand CancelOrder => _cancelOrder ?? (_cancelOrder = new RelayCommand(
            _ =>
            {
                _order.Status = DTOs.OrderStatus.Anulowane;
                _orderStore.EditOrder(Id, _order);
                OnPropertyChanged(nameof(Status));
            },  
            _ => true
        ));

        public AssisstantListItemViewModel(Order order, OrdersStore ordersStore)
        {
            _order = order;
            _orderStore = ordersStore;
        }
    }
}
