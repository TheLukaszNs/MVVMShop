using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.Common.HelperTypes;
using MVVMShop.DB.DbContexts;
using MVVMShop.DTOs;
using MVVMShop.Model;
using MVVMShop.Services.ProductCreators;

namespace MVVMShop.Services.OrderCreators
{
    public class DbOrderCreator : IOrderCreator
    {
        private readonly MVVMShopContextFactory _dbContextFactory;

        public DbOrderCreator(MVVMShopContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public bool CreateOrder(OrderMetadata metadata, Dictionary<Product, uint> products)
        {
            using var context = _dbContextFactory.CreateDbContext();

            var order = ToOrderDto(metadata);
            context.Orders.Add(order);

            foreach (var (product, num) in products)
            {
                order.OrdersProducts.Add(new OrdersProductsDTO
                {
                    OrderId = order.Id,
                    ProductId = product.Id,
                    ProductCount = num
                });
            }

            context.SaveChanges();
            return true;
        }

        private OrderDTO ToOrderDto(OrderMetadata metadata) => new()
        {
            OrdersProducts = new List<OrdersProductsDTO>(),
            Address = $"{metadata.Address} - {metadata.PostalCode}",
            OrderStatus = OrderStatus.WRealizacji,
            PaymentMethod = metadata.PaymentMethod,
            ShipmentMethod = metadata.ShipmentMethod,
            Points = metadata.Points,
            Value = metadata.Value,
            UserId = metadata.UserId,
            Date = DateTime.Now,
        };
    }
}