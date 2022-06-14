using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.DAL.Entities;

namespace MVVMShop.Services.OrderCreator
{
    public interface IOrderCreator
    {
        bool CreateOrder(Orders order, List<Products> products);
    }
}