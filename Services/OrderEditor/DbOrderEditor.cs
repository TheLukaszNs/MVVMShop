using System;
using System.Linq;
using MVVMShop.DB.DbContexts;
using MVVMShop.Model;
using MVVMShop.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MVVMShop.Services.OrderEditor
{
    public class DbOrderEditor : IOrderEditor
    {
        private readonly MVVMShopContextFactory _dbContextFactory;

        public DbOrderEditor(MVVMShopContextFactory dbContextFactory) => _dbContextFactory = dbContextFactory;

        public Order EditOrder(Guid id, Order order)
        {
            using var context = _dbContextFactory.CreateDbContext();

            var _order = context.Orders.Include(o => o.User).FirstOrDefault(o => o.Id == id);
            if (_order == null)
                return null;

            _order.OrderStatus = order.Status;
            context.SaveChanges();

            return ToOrder(_order);
        }

        public Order ToOrder(OrderDTO orderDTO) => new Order
        {
            Id = orderDTO.Id,
            Customer = UserDTOToUser(orderDTO.User),
            Value = orderDTO.Value,
            Address = orderDTO.Address,
            Status = orderDTO.OrderStatus,
            OrderDate = orderDTO.Date,
            Payment = orderDTO.PaymentMethod,
            Delivery = orderDTO.ShipmentMethod,
            Points = orderDTO.Points
        };

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
