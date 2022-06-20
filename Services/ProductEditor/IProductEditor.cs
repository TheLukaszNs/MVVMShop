using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMShop.Services.ProductEditor
{
    public interface IProductEditor
    {
        bool EditProduct(uint? productId);
    }
}
