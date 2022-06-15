using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMShop.Services.OrderCreator
{
    using DAL.Entities;
    using DAL.Repositories;

    internal class DbOrderCreator : IOrderCreator
    {
        #region Properties

        private OrdersRepository ordersRepository;
        private OrderIncludesProductsRepository orderIncludesProductsRepository;

        #endregion

        #region Constructors

        public DbOrderCreator(OrdersRepository ordersRepository, OrderIncludesProductsRepository orderIncludesProductsRepository)
        {
            this.ordersRepository = ordersRepository; 
            this.orderIncludesProductsRepository = orderIncludesProductsRepository;
        }

        #endregion

        #region Methods

        private bool CreateOrder(Orders order, List<Products> products)
        {

        }

        #endregion
    }
}
