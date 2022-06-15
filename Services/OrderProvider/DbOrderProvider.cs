using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMShop.Services.OrderProvider
{
    using DAL.Entities;
    using DAL.Repositories;

    internal class DbOrderProvider : IOrderProvider
    {
        #region Properties

        private OrdersRepository ordersRepository;

        #endregion

        #region Constructors

        public DbOrderProvider(OrdersRepository ordersRepository) => this.ordersRepository = ordersRepository;

        #endregion

        #region Methods

        public Orders GetOrderById(uint id) => ordersRepository.GetOrders().Find(order => order.Id == id);

        public List<Orders> GetOrdersForUser(uint userId) => ordersRepository.GetOrders().FindAll(order => order.IDCustomer == userId);

        public List<Orders> GetOrders() => ordersRepository.GetOrders();

        #endregion
    }
}
