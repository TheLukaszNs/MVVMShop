using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.Common.HelperTypes;
using MVVMShop.Model;

namespace MVVMShop.Services.OrderCreators
{
    public interface IOrderCreator
    {
        bool CreateOrder(OrderMetadata metadata, Dictionary<Product, uint> products);
    }
}