﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.Model;

namespace MVVMShop.Services.ProductCreators
{
    public interface IProductCreator
    {
        bool CreateProduct(Product product);
    }
}