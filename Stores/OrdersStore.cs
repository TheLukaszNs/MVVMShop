using System;
using System.Collections.Generic;
using MVVMShop.Services.OrderProviders;
using MVVMShop.Services.OrderEditor;
using MVVMShop.Model;

namespace MVVMShop.Stores
{
    public class OrdersStore
    {
        private readonly IOrderProvider _orderProvider;
        private readonly IOrderEditor _orderEditor;

        public List<Order> Orders { get; set; } = new();

        public OrdersStore(IOrderProvider orderProvider, IOrderEditor orderEditor)
        {
            _orderProvider = orderProvider;
            _orderEditor = orderEditor;

            InitOrders();
        }

        public event Action OrdersLoaded;
        public event Action OrderChanged;

        private void InitOrders()
        {
            Orders.Clear();
            var orders = _orderProvider.GetAllOrders();

            if (orders != null)
            {
                Orders.AddRange(orders);
                OnOrdersLoaded();
            }
        }

        public void EditOrder(Guid id, Order order)
        {
            var newOrder = _orderEditor.EditOrder(id, order);
            if (newOrder is null)
                return;

            var index = Orders.FindIndex(x => x.Id == id);
            Orders[index] = newOrder;
            OnOrderChanged();
        }

        private void OnOrdersLoaded() => OrdersLoaded?.Invoke();
        private void OnOrderChanged() => OrderChanged?.Invoke();
    }
}
