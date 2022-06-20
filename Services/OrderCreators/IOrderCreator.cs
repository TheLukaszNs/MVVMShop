using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.Model;

namespace MVVMShop.Services.OrderCreators
{
    public interface IOrderCreator
    {
        bool CreateOrder(Order order);
    }
}