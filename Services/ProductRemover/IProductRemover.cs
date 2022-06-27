using System;

namespace MVVMShop.Services.ProductRemover
{
    public interface IProductRemover
    {
        bool RemoveProduct(Guid productId);
    }
}