using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.DAL;
using MVVMShop.DAL.Entities;
using MVVMShop.DAL.Repositories;
using MVVMShop.Model;

namespace MVVMShop.Services.OrderCreators
{
    internal class DbOrderCreator : IOrderCreator
    {
        DbOrderCreator(BaseRepository<Orders> ordersRepository)
        {
        }

        public bool CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}