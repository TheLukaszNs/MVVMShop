using System;
using MVVMShop.Model;

namespace MVVMShop.Services.OrderEditor
{
    public interface IOrderEditor
    {
        Order EditOrder(Guid id, Order order);
    }
}
