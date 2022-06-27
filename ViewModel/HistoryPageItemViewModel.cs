using System;
using MVVMShop.Model;
using MVVMShop.Stores;

namespace MVVMShop.ViewModel
{
    public class HistoryPageItemViewModel : BaseVM
    {
        private Order _order;
        private readonly OrdersStore _ordersStore;

        public Guid Id => _order.Id;
        public uint Points => _order.Points;
        public decimal Price => _order.Value;

        public HistoryPageItemViewModel(Order order, OrdersStore ordersStore)
        {
            _order = order;
            _ordersStore = ordersStore;
        }
    }
}
