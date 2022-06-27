using System.Collections.Generic;
using MVVMShop.Common.HelperTypes;
using MVVMShop.Model;

namespace MVVMShop.Services.OrderCreators
{
    public interface IOrderCreator
    {
        bool CreateOrder(OrderMetadata metadata, Dictionary<Product, uint> products);
    }
}