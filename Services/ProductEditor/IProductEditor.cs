using System;
using MVVMShop.Model;

namespace MVVMShop.Services.ProductEditor
{
    public interface IProductEditor
    {
        Product EditProduct(Guid productId, Product editedProduct);
    }
}