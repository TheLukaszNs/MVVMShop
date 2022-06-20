using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.DTOs;
using MVVMShop.Model;

namespace MVVMShop.Services.ProductEditor
{
    public interface IProductEditor
    {
        Product EditProduct(Guid productId, Product editedProduct);
    }
}