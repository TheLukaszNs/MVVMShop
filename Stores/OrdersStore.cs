using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.Services.OrderProviders;
using MVVMShop.Model;

namespace MVVMShop.Stores
{
    public class OrdersStore
    {
        private readonly IOrderProvider _orderProvider;

        public List<Order> Orders { get; set; } = new();

        public OrdersStore(IOrderProvider orderProvider)
        {
            _orderProvider = orderProvider;

            InitOrders();
        }

        private void InitOrders()
        {
            Orders.Clear();
            var orders = _orderProvider.GetAllOrders();

            if (orders != null)
                Orders.AddRange(orders);
        }
    }
}
