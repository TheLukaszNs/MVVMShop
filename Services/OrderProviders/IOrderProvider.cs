using System.Collections.Generic;
using MVVMShop.Model;

namespace MVVMShop.Services.OrderProviders
{
    public interface IOrderProvider
    {
        IEnumerable<Order> GetAllOrders();
    }
}
