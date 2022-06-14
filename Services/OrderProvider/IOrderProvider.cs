using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.DAL.Entities;

namespace MVVMShop.Services.OrderProvider
{
    public interface IOrderProvider
    {
        Orders GetOrderById(uint id);
        List<Orders> GetOrdersForUser(uint userId);
        List<Orders> GetOrders();
    }
}