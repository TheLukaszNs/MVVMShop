using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMShop.Services.ProductRemover
{
    public interface IProductRemover
    {
        bool RemoveProduct(Guid productId);
    }
}