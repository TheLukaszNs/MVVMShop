using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.Model;

namespace MVVMShop.Services.OrderEditor
{
    public interface IOrderEditor
    {
        Order EditOrder(Guid id, Order order);
    }
}
