using System.Collections.Generic;
using System.Linq;
using MVVMShop.DB.DbContexts;
using MVVMShop.Model;
using MVVMShop.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MVVMShop.Services.OrderProviders
{
    public class DbOrderProvider : IOrderProvider
    {
        private readonly MVVMShopContextFactory _dbContextFactory;

        public DbOrderProvider(MVVMShopContextFactory dbContextFactory) => _dbContextFactory = dbContextFactory;

        public IEnumerable<Order> GetAllOrders()
        {
            using var context = _dbContextFactory.CreateDbContext();

            var orders = context.Orders.Include(o => o.User).ToList();

            return orders.Select(o => new Order
            {
                Id = o.Id,
                Customer = UserDTOToUser(o.User),
                Value = o.Value,
                Address = o.Address,
                Status = o.OrderStatus,
                OrderDate = o.Date,
                Payment = o.PaymentMethod,
                Delivery = o.ShipmentMethod,
                Points = o.Points
            });
        }

        public User UserDTOToUser(UserDTO userDTO) => new User
        {
            Id = userDTO.Id,
            Email = userDTO.Email,
            FirstName = userDTO.FirstName,
            LastName = userDTO.LastName,
            Role = userDTO.Role,
            Points = userDTO.Points
        };
    }
}
